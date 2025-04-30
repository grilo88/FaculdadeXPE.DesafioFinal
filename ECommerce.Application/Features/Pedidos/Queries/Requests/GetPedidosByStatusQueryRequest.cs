using ECommerce.Application.Features.Pedidos.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Queries.Requests
{
    public class GetPedidosByStatusQueryRequest : IRequest<IEnumerable<GetPedidosByStatusQueryResponse>>
    {
        public string Status { get; }

        public GetPedidosByStatusQueryRequest(string status)
        {
            Status = status;
        }
    }
}
