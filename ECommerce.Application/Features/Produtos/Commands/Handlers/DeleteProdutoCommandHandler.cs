using ECommerce.Application.Features.Produtos.Commands.Requests;
using ECommerce.Domain.Services;
using MediatR;

namespace ECommerce.Application.Features.Produtos.Commands.Handlers
{
    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommandRequest, bool>
    {
        private readonly IProdutoService _produtoService;

        public DeleteProdutoCommandHandler(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<bool> Handle(DeleteProdutoCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _produtoService.DeleteProdutoAsync(request.Id);

            return result;
        }
    }
}
