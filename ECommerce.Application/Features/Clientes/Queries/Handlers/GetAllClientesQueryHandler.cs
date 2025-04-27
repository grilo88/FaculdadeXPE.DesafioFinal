using ECommerce.Application.Features.Clientes.Queries.Requests;
using ECommerce.Application.Features.Clientes.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Queries.Handlers
{
    public class GetAllClientesQueryHandler :
        IRequestHandler<GetAllClientesQueryRequest, IEnumerable<GetAllClientesQueryResponse>>
    {
        private readonly IClienteService _clienteService;

        public GetAllClientesQueryHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IEnumerable<GetAllClientesQueryResponse>> Handle(GetAllClientesQueryRequest request, CancellationToken cancellationToken)
        {
            var clientes = await _clienteService.GetAllClientesAsync();

            var response = clientes.Select(cliente => new GetAllClientesQueryResponse
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                Cpf = cliente.Cpf,
            });

            return response;
        }
    }
}
