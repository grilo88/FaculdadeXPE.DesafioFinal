﻿namespace ECommerce.Application.Features.Clientes.Queries.Responses
{
    public class GetClienteByNomeQueryResponse
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public long Telefone { get; set; }

        public string Endereco { get; set; }

        public long Cpf { get; set; }
    }
}
