using MediatR;

namespace ECommerce.Application.Features.Clientes.Commands.Requests
{
    public class UpdateClienteCommandRequest : IRequest<bool>
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public long Cpf { get; set; }

        public long Telefone { get; set; }

        public string Endereco { get; set; }
    }
}
