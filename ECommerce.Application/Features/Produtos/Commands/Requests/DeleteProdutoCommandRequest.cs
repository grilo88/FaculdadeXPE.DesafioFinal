using MediatR;

namespace ECommerce.Application.Features.Produtos.Commands.Requests
{
    public class DeleteProdutoCommandRequest : IRequest<bool>
    {
        public long Id { get; }

        public DeleteProdutoCommandRequest(long id)
        {
            Id = id;
        }
    }
}
