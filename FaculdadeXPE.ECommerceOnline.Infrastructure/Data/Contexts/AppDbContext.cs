using FaculdadeXPE.ECommerceOnline.Domain.Aggregates.Clientes;
using FaculdadeXPE.ECommerceOnline.Domain.Aggregates.Usuarios;
using FaculdadeXPE.ECommerceOnline.Domain.Contracts;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Data.Configurations;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Data.Seeds;
using FaculdadeXPE.ECommerceOnline.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FaculdadeXPE.ECommerceOnline.Infrastructure.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        private IUnitOfWork _unitOfWork;
        
        public IUnitOfWork UnitOfWork => _unitOfWork ??= new UnitOfWork(this);

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuario { get; set; }

        public DbSet<ClienteEntity> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            UsuarioSeed.Seed(modelBuilder);
            ClienteSeed.Seed(modelBuilder);
        }
    }
}
