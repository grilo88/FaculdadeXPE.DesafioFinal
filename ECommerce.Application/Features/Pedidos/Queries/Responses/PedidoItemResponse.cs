namespace ECommerce.Application.Features.Pedidos.Queries.Responses
{
    public class PedidoItemResponse
    {
        public long ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        public decimal Subtotal { get; set; }
    }
}
