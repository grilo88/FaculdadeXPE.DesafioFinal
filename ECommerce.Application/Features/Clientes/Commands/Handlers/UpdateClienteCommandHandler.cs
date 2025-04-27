using ECommerce.Application.Features.Clientes.Commands.Requests;
using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Commands.Handlers
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommandRequest, bool>
    {
        private readonly IClienteService _clienteService;

        public UpdateClienteCommandHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<bool> Handle(UpdateClienteCommandRequest request, CancellationToken cancellationToken)
        {
            var cliente = new ClienteEntity(request.Id, 
                                            request.Nome, 
                                            request.Cpf, 
                                            request.Endereco, 
                                            request.Telefone);

            var result = await _clienteService.UpdateClienteAsync(cliente);

            return result;
        }
    }
}
