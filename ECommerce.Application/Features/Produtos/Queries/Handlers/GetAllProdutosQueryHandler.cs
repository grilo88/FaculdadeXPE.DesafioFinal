using ECommerce.Application.Features.Produtos.Queries.Requests;
using ECommerce.Application.Features.Produtos.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Queries.Handlers
{
    public class GetAllProdutosQueryHandler :
        IRequestHandler<GetAllProdutosQueryRequest, IEnumerable<GetAllProdutosQueryResponse>>
    {
        private readonly IProdutoService _produtoService;

        public GetAllProdutosQueryHandler(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<IEnumerable<GetAllProdutosQueryResponse>> Handle(GetAllProdutosQueryRequest request, CancellationToken cancellationToken)
        {
            var produtos = await _produtoService.GetAllProdutosAsync();

            var response = produtos.Select(produto => new GetAllProdutosQueryResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque
            });

            return response;
        }
    }
}