using ECommerce.Domain.Aggregates.Produtos;
using ECommerce.Domain.Contracts;

namespace ECommerce.Domain.Aggregates.Pedidos
{
    public partial class PedidoEntity
    {
        // Classe interna para os itens do pedido
        public class PedidoItemEntity : Entity
        {
            public long PedidoId { get; private set; }

            public PedidoEntity Pedido { get; private set; }

            public long ProdutoId { get; private set; }

            public ProdutoEntity Produto { get; private set; }

            public int Quantidade { get; private set; }

            public decimal PrecoUnitario { get; private set; }

            public decimal ValorTotal => Quantidade * PrecoUnitario;

            protected PedidoItemEntity() { }

            public PedidoItemEntity(long id, PedidoEntity pedido, ProdutoEntity produto, int quantidade)
            {
                Id = id;
                Pedido = pedido;
                PedidoId = pedido.Id;
                Produto = produto;
                ProdutoId = produto.Id;
                PrecoUnitario = produto.Preco;
                Quantidade = quantidade;
            }

            public PedidoItemEntity(long id,
                                    long pedidoId, 
                                    long produtoId, 
                                    int quantidade, 
                                    decimal precoUnitario)
            {
                Id = id;
                PedidoId = pedidoId;
                ProdutoId = produtoId;
                Quantidade = quantidade;
                PrecoUnitario = precoUnitario;
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