using ECommerce.Domain.Aggregates.Pedidos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<PedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity> builder)
        {
            // Tabela
            builder.ToTable("pedido");

            // Chave primária
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            // Propriedades
            builder.Property(p => p.DataCriado)
                .HasColumnName("data_criado")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("status")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.ValorTotal)
                .HasColumnName("valor_total")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Relacionamento com Cliente
            builder.Property(p => p.ClienteId)
                .HasColumnName("cliente_id")
                .IsRequired();

            builder.HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com Itens (agregação)
            builder.HasMany(p => p.Itens)
                .WithOne()
                .HasForeignKey(i => i.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices
            builder.HasIndex(p => p.ClienteId);
            builder.HasIndex(p => p.DataCriado);
            builder.HasIndex(p => p.Status);
        }
    }
}