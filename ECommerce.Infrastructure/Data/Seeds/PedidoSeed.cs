using ECommerce.Domain.Aggregates.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Seeds
{
    public static class PedidoSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Pedidos
            modelBuilder.Entity<PedidoEntity>().HasData(
                new PedidoEntity(
                    id: 1,
                    clienteId: 1,
                    status: "Aguardando Pagamento",
                    dataCriado: new DateTime(2024, 1, 10))
                );

            modelBuilder.Entity<PedidoEntity>().HasData(
                new PedidoEntity(
                    id: 2,
                    clienteId: 2,
                    status: "Enviado",
                    dataCriado: new DateTime(2024, 1, 10))
                );

            // Itens dos pedidos
            modelBuilder.Entity<PedidoEntity.PedidoItemEntity>().HasData(
                new PedidoEntity.PedidoItemEntity(
                    id: 1,
                    pedidoId: 1,
                    produtoId: 1,
                    quantidade: 5,
                    precoUnitario: 33.4M)
                );

            modelBuilder.Entity<PedidoEntity.PedidoItemEntity>().HasData(
                new PedidoEntity.PedidoItemEntity(
                    id: 2, 
                    pedidoId: 2,
                    produtoId: 2,
                    quantidade: 20,
                    precoUnitario: 43.67M)
                );
        }
    }
}
