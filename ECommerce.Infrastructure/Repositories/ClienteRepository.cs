using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Data.Contexts;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
