using ECommerce.Domain.Contracts;

namespace ECommerce.Domain.Aggregates.Produtos
{
    public class ProdutoEntity : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public decimal Preco { get; private set; }

        public int Estoque { get; private set; }

        protected ProdutoEntity() { }

        public ProdutoEntity(long id)
        {
            Id = id;
        }

        public ProdutoEntity(string nome, string descricao, decimal preco, int estoque)
            : this(0, nome, descricao, preco, estoque) { }

        public ProdutoEntity(long id, string nome, string descricao, decimal preco, int estoque)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
        }

        public void Atualizar(string nome, string descricao, decimal preco, int estoque)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
        }

        public static class Factory
        {
            public static ProdutoEntity CreateSeed(long id, string nome, string descricao, decimal preco, int estoque)
            {
                return new ProdutoEntity()
                {
                    Id = id,
                    Nome = nome,
                    Descricao = descricao,
                    Preco = preco,
                    Estoque = estoque
                };
            }
        }
    }
}
