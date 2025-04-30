using ECommerce.Application.Features.Pedidos.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Queries.Requests
{
    public class GetPedidoByIdQueryRequest : IRequest<GetPedidoByIdQueryResponse?>
    {
        public long Id { get; }

        public GetPedidoByIdQueryRequest(long id)
        {
            Id = id;
        }
    }
}
