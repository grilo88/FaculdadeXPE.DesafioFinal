using ECommerce.Domain.Aggregates.Pedidos;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Data.Contexts;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using static ECommerce.Domain.Aggregates.Pedidos.PedidoEntity;

namespace ECommerce.Infrastructure.Repositories
{
    public class PedidoRepository : Repository<PedidoEntity>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PedidoEntity>> GetPedidosByClienteNomeAsync(string nome)
        {
            return await _context.Pedidos
               .AsNoTracking()
               .Include(x => x.Itens).ThenInclude(x => x.Produto)
               .Where(p => EF.Functions.Like(p.Cliente.Nome, $"%{nome}%"))
               .ToListAsync();
        }

        public async Task<IEnumerable<PedidoEntity>> GetPedidosByStatusAsync(string status)
        {
            return await _context.Pedidos
                .AsNoTracking()
                .Include(x => x.Itens).ThenInclude(x => x.Produto)
                .Where(p => p.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<PedidoEntity>> GetPedidosByClienteIdAsync(long clienteId)
        {
            return await _context.Pedidos
                .AsNoTracking()
                .Include(x => x.Itens).ThenInclude(x => x.Produto)
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<PedidoEntity>> GetAllPedidosAsync()
        {
            return await _context.Pedidos
                .AsNoTracking()
                .Include(x => x.Itens).ThenInclude(x => x.Produto)
                .ToListAsync();
        }

        public async Task<PedidoEntity?> GetPedidoByIdAsync(long id)
        {
            return await _context.Pedidos
                .AsNoTracking()
                .Include(x => x.Itens).ThenInclude(x => x.Produto)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
