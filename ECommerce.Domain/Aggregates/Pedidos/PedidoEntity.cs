using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Aggregates.Produtos;
using ECommerce.Domain.Contracts;

namespace ECommerce.Domain.Aggregates.Pedidos
{
    public partial class PedidoEntity : Entity, IAggregateRoot
    {
        // Propriedades básicas
        public long Id { get; private set; }

        public DateTime DataPedido { get; private set; }

        public string Status { get; private set; }

        public decimal ValorTotal { get; private set; }

        // Relacionamentos
        public long ClienteId { get; private set; }

        public ClienteEntity Cliente { get; private set; }

        // Itens do pedido
        private readonly List<PedidoItem> _itens = new List<PedidoItem>();

        public IReadOnlyCollection<PedidoItem> Itens => _itens.AsReadOnly();

        protected PedidoEntity() { }

        // Construtores
        public PedidoEntity(long id, long clienteId, string status)
            : this(id, clienteId, status, DateTime.UtcNow) { }

        public PedidoEntity(long id, long clienteId, string status, DateTime dataPedido)
        {
            Id = id;
            ClienteId = clienteId;
            Status = status;
            DataPedido = dataPedido;
            ValorTotal = 0;
        }

        // Métodos de negócio
        public void AdicionarItem(ProdutoEntity produto, int quantidade)
        {
            var itemExistente = _itens.FirstOrDefault(i => i.ProdutoId == produto.Id);

            if (itemExistente != null)
            {
                itemExistente.AdicionarQuantidade(quantidade);
            }
            else
            {
                var novoItem = new PedidoItem(this, produto, quantidade);
                _itens.Add(novoItem);
            }

            CalcularValorTotal();
        }

        public void RemoverItem(ProdutoEntity produto, int quantidade)
        {
            var item = _itens.FirstOrDefault(i => i.ProdutoId == produto.Id);

            if (item != null)
            {
                item.RemoverQuantidade(quantidade);

                if (item.Quantidade <= 0)
                {
                    _itens.Remove(item);
                }
            }

            CalcularValorTotal();
        }

        public void AtualizarStatus(string novoStatus)
        {
            Status = novoStatus;
        }

        private void CalcularValorTotal()
        {
            ValorTotal = _itens.Sum(i => i.ValorTotal);
        }

        // Factory para seeds (opcional)
        public static class Factory
        {
            public static PedidoEntity CreateSeed(long id, ClienteEntity cliente, string status, DateTime dataPedido)
            {
                return new PedidoEntity()
                {
                    Id = id,
                    Cliente = cliente,
                    ClienteId = cliente.Id,
                    Status = status,
                    DataPedido = dataPedido
                };
            }
        }
    }
}