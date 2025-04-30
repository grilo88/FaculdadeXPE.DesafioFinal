using ECommerce.Application.Features.Pedidos.Queries.Requests;
using ECommerce.Application.Features.Pedidos.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Queries.Handlers
{
    public class GetPedidosByStatusQueryHandler :
        IRequestHandler<GetPedidosByStatusQueryRequest, IEnumerable<GetPedidosByStatusQueryResponse>>
    {
        private readonly IPedidoService _pedidoService;

        public GetPedidosByStatusQueryHandler(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<IEnumerable<GetPedidosByStatusQueryResponse>> Handle(GetPedidosByStatusQueryRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Status))
                return Enumerable.Empty<GetPedidosByStatusQueryResponse>();

            var pedidos = await _pedidoService.GetPedidosByStatusAsync(request.Status);

            var response = pedidos.Select(p => new GetPedidosByStatusQueryResponse
            {
                Id = p.Id,
                ClienteId = p.ClienteId,
                Status = p.Status,
                ValorTotal = p.ValorTotal,
                DataCriado = p.DataCriado,
                Itens = p.Itens.Select(item => new PedidoItemResponse
                {
                    ProdutoId = item.ProdutoId,
                    Nome = item.Produto.Nome,
                    Descricao = item.Produto.Descricao,
                    Preco = item.PrecoUnitario,
                    Quantidade = item.Quantidade,
                    Subtotal = item.ValorTotal
                }).ToList()
            });

            return response;
        }
    }
}
