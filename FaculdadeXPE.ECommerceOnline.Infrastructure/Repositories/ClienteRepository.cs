using FaculdadeXPE.ECommerceOnline.Domain.Aggregates.Clientes;
using FaculdadeXPE.ECommerceOnline.Domain.Repositories;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Data.Contexts;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Persistence;

namespace FaculdadeXPE.ECommerceOnline.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
