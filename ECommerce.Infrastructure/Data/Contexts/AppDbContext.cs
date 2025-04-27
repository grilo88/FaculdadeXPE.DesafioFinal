using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Contracts;
using ECommerce.Infrastructure.Data.Configurations;
using ECommerce.Infrastructure.Data.Seeds;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        private IUnitOfWork _unitOfWork;
        
        public IUnitOfWork UnitOfWork => _unitOfWork ??= new UnitOfWork(this);

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClienteEntity> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            ClienteSeed.Seed(modelBuilder);
        }
    }
}
