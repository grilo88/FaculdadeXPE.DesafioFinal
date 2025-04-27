using FaculdadeXPE.ECommerceOnline.Domain.Contracts;

namespace FaculdadeXPE.ECommerceOnline.Domain.Aggregates.Usuarios
{
    public class UsuarioEntity : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public string Login { get; private set; }

        public string Senha { get; private set; }

        public DateTime DataCriado {  get; private set; }

        protected UsuarioEntity() { }

        public static class Factory
        {
            public static UsuarioEntity CreateSeed(long id, string nome, string login, string senha)
            {
                return new UsuarioEntity()
                {
                    Id = id,
                    Nome = nome,
                    Login = login,
                    Senha = senha
                };
            }
        }
    }
}
