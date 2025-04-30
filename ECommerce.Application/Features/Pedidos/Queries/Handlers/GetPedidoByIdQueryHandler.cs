using ECommerce.Application.Features.Pedidos.Queries.Requests;
using ECommerce.Application.Features.Pedidos.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Queries.Handlers
{
    public class GetPedidoByIdQueryHandler :
        IRequestHandler<GetPedidoByIdQueryRequest, GetPedidoByIdQueryResponse?>
    {
        private readonly IPedidoService _pedidoService;

        public GetPedidoByIdQueryHandler(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<GetPedidoByIdQueryResponse?> Handle(GetPedidoByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(request.Id);

            if (pedido == null)
                return null;

            var response = new GetPedidoByIdQueryResponse
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                Status = pedido.Status,
                ValorTotal = pedido.ValorTotal,
                DataCriado = pedido.DataCriado,
                Itens = pedido.Itens.Select(item => new PedidoItemResponse
                {
                    ProdutoId = item.ProdutoId,
                    Nome = item.Produto.Nome,
                    Descricao = item.Produto.Descricao,
                    Preco = item.PrecoUnitario,
                    Quantidade = item.Quantidade,
                    Subtotal = item.ValorTotal
                }).ToList()
            };

            return response;
        }
    }
}
