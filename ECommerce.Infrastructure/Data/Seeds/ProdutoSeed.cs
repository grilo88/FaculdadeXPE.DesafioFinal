using ECommerce.Domain.Aggregates.Produtos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Seeds
{
    public static class ProdutoSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoEntity>().HasData(
                new ProdutoEntity(1, "Produto Inicial", "Descrição do Produto Inicial", 99.90m, 50),
                new ProdutoEntity(2, "Produto Extra", "Produto com estoque maior", 49.90m, 100)
            );
        }
    }
}
