using ECommerce.Domain.Aggregates.Pedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoEntity.PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity.PedidoItem> builder)
        {
            // Tabela
            builder.ToTable("pedido_item");

            // Chave primária composta
            builder.HasKey(i => new { i.PedidoId, i.Id });

            // Propriedades
            builder.Property(i => i.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(i => i.PedidoId)
                .HasColumnName("pedido_id")
                .IsRequired();

            builder.Property(i => i.ProdutoId)
                .HasColumnName("produto_id")
                .IsRequired();

            builder.Property(i => i.Quantidade)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(i => i.PrecoUnitario)
                .HasColumnName("preco_unitario")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Relacionamento com Produto
            builder.HasOne(i => i.Produto)
                .WithMany()
                .HasForeignKey(i => i.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices
            builder.HasIndex(i => i.ProdutoId);
        }
    }
}