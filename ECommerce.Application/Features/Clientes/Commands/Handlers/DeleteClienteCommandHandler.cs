using ECommerce.Application.Features.Clientes.Commands.Requests;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Commands.Handlers
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommandRequest, bool>
    {
        private readonly IClienteService _clienteService;

        public DeleteClienteCommandHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<bool> Handle(DeleteClienteCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _clienteService.DeleteClienteAsync(request.Id);

            return result;
        }
    }
}
