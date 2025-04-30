using ECommerce.Application.Features.Pedidos.Queries.Requests;
using ECommerce.Application.Features.Pedidos.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Queries.Handlers
{
    public class GetPedidoByNomeQueryHandler :
        IRequestHandler<GetPedidosByClienteNomeQueryRequest, IEnumerable<GetPedidosByClienteNomeQueryResponse>>
    {
        private readonly IPedidoService _pedidoService;

        public GetPedidoByNomeQueryHandler(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<IEnumerable<GetPedidosByClienteNomeQueryResponse>> Handle(GetPedidosByClienteNomeQueryRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Nome))
                return Enumerable.Empty<GetPedidosByClienteNomeQueryResponse>();

            var pedidos = await _pedidoService.GetPedidosByNomeAsync(request.Nome);

            if (pedidos == null || !pedidos.Any())
                return Enumerable.Empty<GetPedidosByClienteNomeQueryResponse>();

            var response = pedidos.Select(p => new GetPedidosByClienteNomeQueryResponse
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
