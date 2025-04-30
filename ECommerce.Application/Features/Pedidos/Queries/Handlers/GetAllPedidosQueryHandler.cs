using ECommerce.Application.Features.Pedidos.Queries.Requests;
using ECommerce.Application.Features.Pedidos.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Queries.Handlers
{
    public class GetAllPedidosQueryHandler :
        IRequestHandler<GetAllPedidosQueryRequest, IEnumerable<GetAllPedidosQueryResponse>>
    {
        private readonly IPedidoService _pedidoService;

        public GetAllPedidosQueryHandler(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<IEnumerable<GetAllPedidosQueryResponse>> Handle(GetAllPedidosQueryRequest request, CancellationToken cancellationToken)
        {
            var pedidos = await _pedidoService.GetAllPedidosAsync();

            var response = pedidos.Select(pedido => new GetAllPedidosQueryResponse
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
            });

            return response;
        }
    }
}
