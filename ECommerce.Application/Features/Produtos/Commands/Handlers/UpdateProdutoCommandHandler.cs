using ECommerce.Application.Features.Produtos.Commands.Requests;
using ECommerce.Domain.Aggregates.Produtos;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Commands.Handlers
{
    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommandRequest, bool>
    {
        private readonly IProdutoService _produtoService;

        public UpdateProdutoCommandHandler(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<bool> Handle(UpdateProdutoCommandRequest request, CancellationToken cancellationToken)
        {
            var produto = new ProdutoEntity(request.Id,
                                            request.Nome,
                                            request.Descricao,
                                            request.Preco,
                                            request.Estoque);

            var result = await _produtoService.UpdateProdutoAsync(produto);

            return result;
        }
    }
}
