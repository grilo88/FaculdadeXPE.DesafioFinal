using MediatR;

namespace ECommerce.Application.Features.Pedidos.Commands.Requests
{
    public class DeletePedidoCommandRequest : IRequest<bool>
    {
        public long Id { get; }

        public DeletePedidoCommandRequest(long id)
        {
            Id = id;
        }
    }
}
