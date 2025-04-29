using ECommerce.Domain.Aggregates.Produtos;
using ECommerce.Domain.Contracts;

namespace ECommerce.Domain.Aggregates.Pedidos
{
    public partial class PedidoEntity
    {
        // Classe interna para os itens do pedido
        public class PedidoItem : Entity
        {
            public long PedidoId { get; private set; }

            public PedidoEntity Pedido { get; private set; }

            public long ProdutoId { get; private set; }

            public ProdutoEntity Produto { get; private set; }

            public int Quantidade { get; private set; }

            public decimal PrecoUnitario { get; private set; }

            public decimal ValorTotal => Quantidade * PrecoUnitario;

            protected PedidoItem() { }

            internal PedidoItem(PedidoEntity pedido, ProdutoEntity produto, int quantidade)
            {
                Pedido = pedido;
                PedidoId = pedido.Id;
                Produto = produto;
                ProdutoId = produto.Id;
                PrecoUnitario = produto.Preco;
                Quantidade = quantidade;
            }

            internal void AdicionarQuantidade(int quantidade)
            {
                Quantidade += quantidade;
            }

            internal void RemoverQuantidade(int quantidade)
            {
                Quantidade = Math.Max(0, Quantidade - quantidade);
            }
        }
    }
}