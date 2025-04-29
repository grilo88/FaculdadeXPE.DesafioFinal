using ECommerce.Application.Features.Produtos.Queries.Requests;
using ECommerce.Application.Features.Produtos.Queries.Responses;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Queries.Handlers
{
    public class GetProdutoByIdQueryHandler :
        IRequestHandler<GetProdutoByIdQueryRequest, GetProdutoByIdQueryResponse?>
    {
        private readonly IProdutoService _produtoService;

        public GetProdutoByIdQueryHandler(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<GetProdutoByIdQueryResponse?> Handle(GetProdutoByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(request.Id);

            if (produto == null)
                return null;

            var response = new GetProdutoByIdQueryResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Estoque = produto.Estoque
            };

            return response;
        }
    }
}