using ECommerce.Application.Features.Clientes.Queries.Requests;
using ECommerce.Application.Features.Clientes.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Queries.Handlers
{
    public class GetClienteByNomeQueryHandler :
        IRequestHandler<GetClienteByNomeQueryRequest, IEnumerable<GetClienteByNomeQueryResponse>>
    {
        private readonly IClienteService _clienteService;

        public GetClienteByNomeQueryHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IEnumerable<GetClienteByNomeQueryResponse>> Handle(GetClienteByNomeQueryRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Nome))
                return Enumerable.Empty<GetClienteByNomeQueryResponse>();

            var clientes = await _clienteService.GetClienteByNameAsync(request.Nome);

            var response = clientes.Select(cliente => new GetClienteByNomeQueryResponse()
            {
                Id = cliente.Id,
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco
            });

            return response;
        }
    }
}
