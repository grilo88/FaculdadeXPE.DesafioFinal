using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Data.Contexts;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClienteEntity>> GetByNomeAsync(string nome)
        {
            return await _context.Cliente
               .Where(c => EF.Functions.Like(c.Nome, $"%{nome}%"))
               .ToListAsync();
        }
    }
}
