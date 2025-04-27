using ECommerce.Domain.Aggregates.Clientes;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Seeds
{
    public static class ClienteSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteEntity>().HasData(
                ClienteEntity.Factory.CreateSeed(1, "Cliente Admin", 11111111111, "Rua Teste, 123"),
                ClienteEntity.Factory.CreateSeed(2, "Cliente Comum", 22222222222, "Rua Teste, 124")
            );
        }
    }
}
