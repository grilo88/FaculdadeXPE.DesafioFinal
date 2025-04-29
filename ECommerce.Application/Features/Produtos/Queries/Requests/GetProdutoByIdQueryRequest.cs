using ECommerce.Application.Features.Produtos.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Queries.Requests
{
    public class GetProdutoByIdQueryRequest : IRequest<GetProdutoByIdQueryResponse?>
    {
        public long Id { get; }

        public GetProdutoByIdQueryRequest(long id)
        {
            Id = id;
        }
    }
}