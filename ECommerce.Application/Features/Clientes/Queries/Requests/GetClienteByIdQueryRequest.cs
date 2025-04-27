using ECommerce.Application.Features.Clientes.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Queries.Requests
{
    public class GetClienteByIdQueryRequest : IRequest<GetClienteByIdQueryResponse?>
    {
        public long Id { get; }

        public GetClienteByIdQueryRequest(long id)
        {
            Id = id;
        }
    }
}
