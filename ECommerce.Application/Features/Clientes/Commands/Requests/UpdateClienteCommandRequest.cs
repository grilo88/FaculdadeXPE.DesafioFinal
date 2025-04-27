using MediatR;

namespace ECommerce.Application.Features.Clientes.Commands.Requests
{
    public class UpdateClienteCommandRequest : IRequest<bool>
    {
        public long Id { get; set; }

        public string Nome { get; }

        public long Cpf { get; }

        public long Telefone { get; }

        public string Endereco { get; }
    }
}
