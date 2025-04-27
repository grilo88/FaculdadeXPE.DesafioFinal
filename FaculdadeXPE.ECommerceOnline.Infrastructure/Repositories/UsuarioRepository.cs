using FaculdadeXPE.ECommerceOnline.Domain.Aggregates.Usuarios;
using FaculdadeXPE.ECommerceOnline.Domain.Repositories;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Data.Contexts;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Persistence;

namespace FaculdadeXPE.ECommerceOnline.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
