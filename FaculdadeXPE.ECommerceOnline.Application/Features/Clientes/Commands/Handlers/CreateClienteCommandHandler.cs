using FaculdadeXPE.ECommerceOnline.Application.Features.Clientes.Commands.Requests;
using FaculdadeXPE.ECommerceOnline.Domain.Aggregates.Clientes;
using FaculdadeXPE.ECommerceOnline.Domain.Contracts;
using FaculdadeXPE.ECommerceOnline.Domain.Repositories;
using MediatR;

namespace FaculdadeXPE.ECommerceOnline.Application.Features.Clientes.Commands.Handlers
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
