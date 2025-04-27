using ECommerce.Application.Features.Clientes.Commands.Requests;
using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Commands.Handlers
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommandRequest, bool>
    {
        private readonly IClienteService _clienteService;  

        public CreateClienteCommandHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<bool> Handle(CreateClienteCommandRequest request, CancellationToken cancellationToken)
        {
            var cliente = new ClienteEntity(request.Nome,
                                            request.Cpf,
                                            request.Endereco,
                                            request.Telefone);

            var result = await _clienteService.CreateClienteAsync(cliente);

            return result;
        }
    }
}
