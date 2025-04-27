using MediatR;

namespace ECommerce.Application.Features.Clientes.Commands.Requests
{
    public class DeleteClienteCommandRequest : IRequest<bool>
    {
        public long Id { get; }

        public DeleteClienteCommandRequest(long id)
        {
            Id = id;
        }
    }
}
