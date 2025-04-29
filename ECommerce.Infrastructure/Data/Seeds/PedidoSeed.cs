using ECommerce.Domain.Aggregates.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Seeds
{
    public static class PedidoSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoEntity>().HasData(
                new PedidoEntity(
                    id: 1,
                    clienteId: 1,
                    status: "Aguardando Pagamento",
                    dataPedido: new DateTime(2024, 1, 10))
                );

            modelBuilder.Entity<PedidoEntity>().HasData(
                new PedidoEntity(
                    id: 2,
                    clienteId: 2,
                    status: "Enviado",
                    dataPedido: new DateTime(2024, 1, 10))
                );
        }
    }
}
