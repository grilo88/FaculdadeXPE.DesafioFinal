using MediatR;

namespace ECommerce.Application.Features.Clientes.Commands.Requests
{
    public class CreateClienteCommandRequest : IRequest<bool>
    {
        public long UsuarioId { get; }

        public string Nome { get; }

        public long Cpf { get; }

        public string Endereco { get; }

        public long Telefone { get; }
    }
}
