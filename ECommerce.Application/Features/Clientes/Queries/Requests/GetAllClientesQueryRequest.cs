using ECommerce.Application.Features.Clientes.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Clientes.Queries.Requests
{
    public class GetAllClientesQueryRequest : IRequest<IEnumerable<GetAllClientesQueryResponse>>
    {
    }
}
