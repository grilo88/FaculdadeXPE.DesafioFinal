using MediatR;

namespace ECommerce.Application.Features.Produtos.Commands.Requests
{
    public class UpdateProdutoCommandRequest : IRequest<bool>
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }
    }
}
