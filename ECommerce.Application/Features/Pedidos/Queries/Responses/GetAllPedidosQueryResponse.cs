namespace ECommerce.Application.Features.Pedidos.Queries.Responses
{
    public class GetAllPedidosQueryResponse
    {
        public long Id { get; set; }

        public long ClienteId { get; set; }

        public string Status { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataCriado { get; set; }

        public List<PedidoItemResponse> Itens { get; set; }
    }
}
