using ECommerce.Domain.Aggregates.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            // Definindo o nome da tabela no banco de dados
            builder.ToTable("usuario");

            // Definindo a chave primária
            builder.HasKey(u => u.Id);

            // Definindo as propriedades da entidade
            builder.Property(u => u.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Login)
                .HasColumnName("login")
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("senha")
                .IsRequired();

            builder.Property(u => u.DataCriado)
                .HasColumnName("data_criado")
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasIndex(u => u.Login)
                .IsUnique();
        }
    }
}
