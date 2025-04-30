using ECommerce.Domain.Aggregates.Clientes;
using ECommerce.Domain.Aggregates.Produtos;
using ECommerce.Domain.Contracts;

namespace ECommerce.Domain.Aggregates.Pedidos
{
    public partial class PedidoEntity : Entity, IAggregateRoot
    {
        // Propriedades básicas
        public string Status { get; private set; }

        public decimal ValorTotal { get; private set; }

        // Relacionamentos
        public long ClienteId { get; private set; }

        public ClienteEntity Cliente { get; private set; }

        // Itens do pedido
        private readonly List<PedidoItemEntity> _itens = new List<PedidoItemEntity>();

        public IReadOnlyCollection<PedidoItemEntity> Itens => _itens.AsReadOnly();

        public DateTime DataCriado { get; private set; }

        protected PedidoEntity() { }

        // Construtores
        public PedidoEntity(long id, long clienteId, string status)
            : this(id, clienteId, status, DateTime.UtcNow) { }

        public PedidoEntity(long id, long clienteId, string status, DateTime dataCriado)
        {
            Id = id;
            ClienteId = clienteId;
            Status = status;
            DataCriado = dataCriado;
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
                var novoItem = new PedidoItemEntity(0, this, produto, quantidade);
                _itens.Add(novoItem);
            }

            CalcularValorTotal();
        }

        public void RemoverItem(long produtoId, int quantidade)
        {
            var item = _itens.FirstOrDefault(i => i.ProdutoId == produtoId);

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

        public void DefinirItens(IEnumerable<PedidoItemEntity> itens)
        {
            _itens.Clear(); 
            foreach (var item in itens)
            {
                _itens.Add(item);
            }

            CalcularValorTotal();
        }

        public void Atualizar(long clienteId,
                              string status,
                              List<PedidoItemEntity> itensValidados)
        {
            ClienteId = clienteId;
            Status = status;

            DefinirItens(itensValidados);
        }
    }
}