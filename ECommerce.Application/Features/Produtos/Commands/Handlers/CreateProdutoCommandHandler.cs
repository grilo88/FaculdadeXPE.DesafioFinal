using ECommerce.Application.Features.Produtos.Commands.Requests;
using ECommerce.Domain.Aggregates.Produtos;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Commands.Handlers
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommandRequest, bool>
    {
        private readonly IProdutoService _produtoService;

        public CreateProdutoCommandHandler(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<bool> Handle(CreateProdutoCommandRequest request, CancellationToken cancellationToken)
        {
            var produto = new ProdutoEntity(request.Nome,
                                            request.Descricao,
                                            request.Preco,
                                            request.Estoque);

            var result = await _produtoService.CreateProdutoAsync(produto);

            return result;
        }
    }
}
