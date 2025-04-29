using ECommerce.Domain.Aggregates.Produtos;

namespace ECommerce.Domain.Services
{
    public interface IProdutoService
    {
        Task<bool> CreateProdutoAsync(ProdutoEntity produto);

        Task<bool> DeleteProdutoAsync(long id);

        Task<IEnumerable<ProdutoEntity>> GetAllProdutosAsync();

        Task<IEnumerable<ProdutoEntity>> GetProdutoByNameAsync(string nome);

        Task<ProdutoEntity> GetProdutoByIdAsync(long id);

        Task<bool> UpdateProdutoAsync(ProdutoEntity produto);
    }
}
