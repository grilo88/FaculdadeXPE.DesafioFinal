using ECommerce.Domain.Aggregates.Produtos;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;

namespace ECommerce.Application.Features.Produtos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IUnitOfWork unitOfWork,
                              IProdutoRepository produtoRepository)
        {
            _unitOfWork = unitOfWork;
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> CreateProdutoAsync(ProdutoEntity produto)
        {
            if (string.IsNullOrEmpty(produto.Nome) ||
                produto.Preco <= 0 ||
                produto.Estoque < 0)
            {
                return false; // Dados inválidos
            }

            await _produtoRepository.AddAsync(produto);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteProdutoAsync(long id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                return false; // Produto não encontrado
            }

            await _produtoRepository.DeleteAsync(produto.Id);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> UpdateProdutoAsync(ProdutoEntity produto)
        {
            var produtoExistente = await _produtoRepository.GetByIdAsync(produto.Id);
            if (produtoExistente == null)
            {
                return false; // Produto não encontrado
            }

            produtoExistente.Atualizar(produto.Nome,
                                       produto.Descricao,
                                       produto.Preco,
                                       produto.Estoque);

            await _produtoRepository.UpdateAsync(produtoExistente);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<ProdutoEntity>> GetAllProdutosAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<ProdutoEntity> GetProdutoByIdAsync(long id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProdutoEntity>> GetProdutoByNameAsync(string nome)
        {
            return await _produtoRepository.GetByNomeAsync(nome);
        }
    }
}
