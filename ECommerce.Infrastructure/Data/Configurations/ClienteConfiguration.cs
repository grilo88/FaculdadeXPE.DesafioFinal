using ECommerce.Domain.Aggregates.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            // Definindo o nome da tabela no banco
            builder.ToTable("cliente");

            // Definindo a chave primária
            builder.HasKey(c => c.Id);

            // Definindo as propriedades
            builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(c => c.UsuarioId)
                .HasColumnName("usuario_id");

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Cpf)
                .HasColumnName("cpf")
                .IsRequired()
                .HasMaxLength(11);
            
            builder.Property(c => c.Endereco)
                .HasColumnName("endereco")
                .HasMaxLength(255);

            builder.Property(c => c.Telefone)
                .HasColumnName("telefone")
                .HasMaxLength(15);

            builder.HasIndex(c => c.Cpf).IsUnique();

            // Relacionamento com UsuarioEntity
            builder.HasOne(c => c.Usuario)
                .WithMany() // Ou .WithOne() se for um relacionamento 1-1
                .HasForeignKey(c => c.UsuarioId) // Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); // Configuração de comportamento em caso de exclusão
        }
    }
}
