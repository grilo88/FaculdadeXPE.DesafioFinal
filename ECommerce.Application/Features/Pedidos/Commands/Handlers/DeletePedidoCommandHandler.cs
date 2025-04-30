using ECommerce.Application.Features.Pedidos.Commands.Requests;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Commands.Handlers
{
    public class DeletePedidoCommandHandler : IRequestHandler<DeletePedidoCommandRequest, bool>
    {
        private readonly IPedidoService _pedidoService;

        public DeletePedidoCommandHandler(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<bool> Handle(DeletePedidoCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _pedidoService.DeletePedidoAsync(request.Id);

            return result;
        }
    }
}
