namespace ECommerce.Application.Features.Produtos.Queries.Responses
{
    public class GetProdutoByStatusQueryResponse
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }
    }
}