using ECommerce.Domain.Aggregates.Produtos;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Data.Contexts;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProdutoRepository : Repository<ProdutoEntity>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProdutoEntity>> GetByNomeAsync(string nome)
        {
            return await _context.Produtos
               .AsNoTracking()
               .Where(p => EF.Functions.Like(p.Nome, $"%{nome}%"))
               .ToListAsync();
        }
    }
}