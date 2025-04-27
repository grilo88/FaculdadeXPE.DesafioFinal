using MediatR;

namespace FaculdadeXPE.ECommerceOnline.Application.Features.Clientes.Commands.Requests
{
    public class CreateClienteCommandRequest : IRequest<bool>
    {
        public string Nome { get; }

        public long Cpf { get; }

        public string Endereco { get; }

        public long Telefone { get; }

        public CreateClienteCommandRequest(string nome,
                                           long cpf,
                                           string endereco,
                                           long telefone) 
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
        }    
    }
}
