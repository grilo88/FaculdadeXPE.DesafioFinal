using ECommerce.Application.Features.Clientes.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Queries.Requests
{
    public class GetClienteByNomeQueryRequest : IRequest<IEnumerable<GetClienteByNomeQueryResponse>>
    {
        public string Nome { get; }

        public GetClienteByNomeQueryRequest(string nome)
        {
            Nome = nome;
        }
    }
}
