using ECommerce.Application.Features.Pedidos.Commands.Requests;
using ECommerce.Domain.Aggregates.Pedidos;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Commands.Handlers
{
    public class CreatePedidoCommandHandler : IRequestHandler<CreatePedidoCommandRequest, bool>
    {
        private readonly IPedidoService _pedidoService;

        public CreatePedidoCommandHandler(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<bool> Handle(CreatePedidoCommandRequest request, CancellationToken cancellationToken)
        {
            var pedido = new PedidoEntity(request.Id, 
                                          request.ClienteId, 
                                          request.Status);

            return await _pedidoService.CreatePedidoAsync(pedido, request.Itens);
        }
    }
}
