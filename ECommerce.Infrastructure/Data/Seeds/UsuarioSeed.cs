using ECommerce.Domain.Aggregates.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Seeds
{
    public static class UsuarioSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Dados seed para a tabela Usuario
            modelBuilder.Entity<UsuarioEntity>().HasData(
                UsuarioEntity.Factory.CreateSeed(1, "Usuário Administrador", "admin", "123456"),
                UsuarioEntity.Factory.CreateSeed(2, "Usuário Comum", "comum", "123456")
            );
        }
    }
}
