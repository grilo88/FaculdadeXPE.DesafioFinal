namespace ECommerce.Domain.Aggregates.Pedidos.DTOs
{
    public class PedidoItemDto
    {
        public int Id { get; set; } 

        public long ProdutoId { get; init; }

        public int Quantidade { get; init; }
    }
}
