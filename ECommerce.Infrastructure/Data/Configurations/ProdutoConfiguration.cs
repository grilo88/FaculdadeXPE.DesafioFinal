using ECommerce.Domain.Aggregates.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            // Nome da tabela
            builder.ToTable("produto");

            // Chave primária
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(500);

            builder.Property(p => p.Preco)
                .HasColumnName("preco")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Estoque)
                .HasColumnName("estoque")
                .IsRequired();
        }
    }
}
