using ECommerce.Domain.Aggregates.Produtos;
using ECommerce.Domain.Contracts;

namespace ECommerce.Domain.Repositories
{
    public interface IProdutoRepository : IRepository<ProdutoEntity>
    {
        Task<IEnumerable<ProdutoEntity>> GetByNomeAsync(string nome);
    }
}
