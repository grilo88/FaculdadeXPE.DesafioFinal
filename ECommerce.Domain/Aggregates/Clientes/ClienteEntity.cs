using ECommerce.Domain.Contracts;

namespace ECommerce.Domain.Aggregates.Clientes
{
    public class ClienteEntity : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public long Cpf { get; private set; }

        public string Endereco { get; private set; }

        public long Telefone { get; private set; }

        protected ClienteEntity() { }

        public ClienteEntity(string nome, long cpf, string endereco, long telefone):
            this(0, nome, cpf, endereco, telefone) { }

        public ClienteEntity(long id, string nome, long cpf, string endereco, long telefone)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
        }

        public void Atualizar(string nome, long cpf, string endereco, long telefone)
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
                    Nome = nome,
                    Cpf = cpf,
                    Endereco = endereco
                };
            }
        }
    }
}
