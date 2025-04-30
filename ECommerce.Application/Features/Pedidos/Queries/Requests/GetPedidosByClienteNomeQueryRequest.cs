using ECommerce.Application.Features.Pedidos.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Pedidos.Queries.Requests
{
    public class GetPedidosByClienteNomeQueryRequest : IRequest<IEnumerable<GetPedidosByClienteNomeQueryResponse>>
    {
        public string Nome { get; }

        public GetPedidosByClienteNomeQueryRequest(string nome)
        {
            Nome = nome;
        }
    }
}
