using MediatR;

namespace ECommerce.Application.Features.Produtos.Commands.Requests
{
    public class CreateProdutoCommandRequest : IRequest<bool>
    {
        public string Nome { get; }

        public string Descricao { get; }

        public decimal Preco { get; }

        public int Estoque { get; }
    }
}
