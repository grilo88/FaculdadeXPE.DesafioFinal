using ECommerce.Application.Features.Produtos.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Queries.Requests
{
    public class GetProdutoByNomeQueryRequest : IRequest<IEnumerable<GetProdutoByNomeQueryResponse>>
    {
        public string Nome { get; }

        public GetProdutoByNomeQueryRequest(string nome)
        {
            Nome = nome;
        }
    }
}