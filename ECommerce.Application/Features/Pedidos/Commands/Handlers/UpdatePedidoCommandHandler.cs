using ECommerce.Application.Features.Pedidos.Commands.Requests;
using ECommerce.Domain.Aggregates.Pedidos;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Commands.Handlers
{
    public class UpdatePedidoCommandHandler : IRequestHandler<UpdatePedidoCommandRequest, bool>
    {
        private readonly IPedidoService _pedidoService;

        public UpdatePedidoCommandHandler(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<bool> Handle(UpdatePedidoCommandRequest request, CancellationToken cancellationToken)
        {
            var pedido = new PedidoEntity(request.Id,
                                          request.ClienteId,
                                          request.Status);

            var result = await _pedidoService.UpdatePedidoAsync(pedido, request.Itens);

            return result;
        }
    }
}
