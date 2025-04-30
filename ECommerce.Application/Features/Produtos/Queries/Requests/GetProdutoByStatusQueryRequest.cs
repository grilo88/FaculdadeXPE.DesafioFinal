using ECommerce.Application.Features.Produtos.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Queries.Requests
{
    public class GetProdutoByStatusQueryRequest : IRequest<IEnumerable<GetProdutoByStatusQueryResponse>>
    {
        public string Nome { get; }

        public GetProdutoByStatusQueryRequest(string nome)
        {
            Nome = nome;
        }
    }
}