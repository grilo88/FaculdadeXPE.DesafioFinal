using ECommerce.Domain.Aggregates.Pedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoEntity.PedidoItemEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity.PedidoItemEntity> builder)
        {
            // Tabela
            builder.ToTable("pedido_item");

            // Chave primária
            builder.HasKey(i => i.Id);

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

            // Relacionamento com Pedido
            builder.HasOne(i => i.Pedido)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices
            builder.HasIndex(i => i.ProdutoId);
        }
    }
}
