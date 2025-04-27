using FaculdadeXPE.ECommerceOnline.Domain.Aggregates.Usuarios;
using FaculdadeXPE.ECommerceOnline.Domain.Contracts;

namespace FaculdadeXPE.ECommerceOnline.Domain.Aggregates.Clientes
{
    public class ClienteEntity : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public long Cpf { get; private set; }

        public string Endereco { get; private set; }

        public long Telefone { get; private set; }

        public long UsuarioId { get; private set; }
        
        public UsuarioEntity Usuario { get; private set; } // Navegação para o UsuarioEntity

        protected ClienteEntity() { }

        public ClienteEntity(string nome, long cpf, string endereco, long telefone)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
        }

        public static class Factory
        {
            public static ClienteEntity CreateSeed(long id, string nome, long cpf, string endereco)
            {
                return new ClienteEntity()
                {
                    Id = id,
                    UsuarioId = id,
                    Nome = nome,
                    Cpf = cpf,
                    Endereco = endereco
                };
            }
        }
    }
}
