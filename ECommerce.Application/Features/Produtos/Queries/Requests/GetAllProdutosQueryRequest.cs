using ECommerce.Application.Features.Produtos.Queries.Responses;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Queries.Requests
{
    public class GetAllProdutosQueryRequest : IRequest<IEnumerable<GetAllProdutosQueryResponse>>
    {
    }
}