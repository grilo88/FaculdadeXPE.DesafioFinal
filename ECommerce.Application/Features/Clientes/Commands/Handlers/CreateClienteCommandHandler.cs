using ECommerce.Application.Features.Clientes.Commands.Requests;
using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Repositories;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Commands.Handlers
{
    public class CreateClienteCommandHandler : 
        IRequestHandler<CreateClienteCommandRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandHandler(IUnitOfWork unitOfWork,
                                           IClienteRepository clienteRepository)
        {
            _unitOfWork = unitOfWork;
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(CreateClienteCommandRequest request, CancellationToken cancellationToken)
        {
            var cliente = new ClienteEntity(request.Nome,
                                            request.Cpf,
                                            request.Endereco,
                                            request.Telefone);

            await _clienteRepository.AddAsync(cliente);
            await _unitOfWork.CommitAsync(); 

            return true;
        }
    }
}
