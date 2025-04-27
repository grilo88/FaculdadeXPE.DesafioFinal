using ECommerce.Application.Features.Clientes.Queries.Requests;
using ECommerce.Application.Features.Clientes.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Queries.Handlers
{
    public class GetClienteByIdQueryHandler :
        IRequestHandler<GetClienteByIdQueryRequest, GetClienteByIdQueryResponse?>
    {
        private readonly IClienteService _clienteService;

        public GetClienteByIdQueryHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<GetClienteByIdQueryResponse?> Handle(GetClienteByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteService.ObterClientePorIdAsync(request.Id);

            if (cliente == null)
                return null;

            var response = new GetClienteByIdQueryResponse
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Endereco = cliente.Endereco,
                Telefone = cliente.Telefone
            };

            return response;
        }
    }
}
