using ECommerce.Domain.Aggregates.Usuarios;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Data.Contexts;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
