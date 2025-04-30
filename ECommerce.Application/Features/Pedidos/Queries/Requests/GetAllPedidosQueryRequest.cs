using ECommerce.Application.Features.Pedidos.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Queries.Requests
{
    public class GetAllPedidosQueryRequest : IRequest<IEnumerable<GetAllPedidosQueryResponse>>
    {
    }
}
