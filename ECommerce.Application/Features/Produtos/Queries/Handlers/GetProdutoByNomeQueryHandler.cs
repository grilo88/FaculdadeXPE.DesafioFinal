using ECommerce.Application.Features.Produtos.Queries.Requests;
using ECommerce.Application.Features.Produtos.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Queries.Handlers
{
    public class GetProdutoByNomeQueryHandler :
        IRequestHandler<GetProdutoByNomeQueryRequest, IEnumerable<GetProdutoByNomeQueryResponse>>
    {
        private readonly IProdutoService _produtoService;

        public GetProdutoByNomeQueryHandler(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<IEnumerable<GetProdutoByNomeQueryResponse>> Handle(GetProdutoByNomeQueryRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Nome))
                return Enumerable.Empty<GetProdutoByNomeQueryResponse>();

            var produtos = await _produtoService.GetProdutoByNameAsync(request.Nome);

            var response = produtos.Select(produto => new GetProdutoByNomeQueryResponse()
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