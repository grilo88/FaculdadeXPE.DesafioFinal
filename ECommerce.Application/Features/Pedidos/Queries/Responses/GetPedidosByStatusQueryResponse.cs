namespace ECommerce.Application.Features.Pedidos.Queries.Responses
{
    public class GetPedidosByStatusQueryResponse
    {
        public long Id { get; set; }

        public long ClienteId { get; set; }

        public string Status { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTime DataCriado { get; set; }

        // Lista de itens do pedido
        public List<PedidoItemResponse> Itens { get; set; }

        public GetPedidosByStatusQueryResponse()
        {
            Itens = new List<PedidoItemResponse>();
        }
    }
}
