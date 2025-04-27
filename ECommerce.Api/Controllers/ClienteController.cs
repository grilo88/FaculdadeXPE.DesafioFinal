using ECommerce.Application.Features.Clientes.Commands.Requests;
using ECommerce.Application.Features.Clientes.Queries.Requests;
using ECommerce.Application.Features.Clientes.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST /cliente
        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo cliente", Description = "Cria um novo cliente no sistema.")]
        [SwaggerResponse(200, "Cliente criado com sucesso.", typeof(bool))]
        [SwaggerResponse(400, "Falha ao criar cliente.", typeof(string))]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteCommandRequest request)
        {
            if (request == null)
                return BadRequest("Dados do cliente não podem ser nulos.");

            try
            {
                var result = await _mediator.Send(request);

                if (result)
                    return Ok("Cliente criado com sucesso.");

                return BadRequest("Falha ao criar cliente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // DELETE /cliente/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um cliente", Description = "Deleta o cliente com o ID especificado.")]
        [SwaggerResponse(200, "Cliente deletado com sucesso.", typeof(bool))]
        [SwaggerResponse(400, "ID inválido.", typeof(string))]
        [SwaggerResponse(404, "Cliente não encontrado.", typeof(string))]
        public async Task<IActionResult> DeleteCliente(long id)
        {
            if (id == 0)
                return BadRequest("ID inválido.");

            try
            {
                var result = await _mediator.Send(new DeleteClienteCommandRequest(id));

                if (result)
                    return Ok("Cliente deletado com sucesso.");

                return NotFound("Cliente não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // PUT /cliente/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um cliente", Description = "Atualiza os dados de um cliente com o ID especificado.")]
        [SwaggerResponse(200, "Cliente atualizado com sucesso.", typeof(bool))]
        [SwaggerResponse(400, "Dados inválidos para atualização.", typeof(string))]
        [SwaggerResponse(404, "Cliente não encontrado para atualização.", typeof(string))]
        public async Task<IActionResult> UpdateCliente(long id, [FromBody] UpdateClienteCommandRequest request)
        {
            if (request == null || id == 0)
                return BadRequest("Dados inválidos para atualização.");

            try
            {
                request.Id = id;
                var result = await _mediator.Send(request);

                if (result)
                    return Ok("Cliente atualizado com sucesso.");

                return NotFound("Cliente não encontrado para atualização.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET /cliente
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os clientes", Description = "Obtém todos os clientes cadastrados.")]
        [SwaggerResponse(200, "Lista de clientes.", typeof(IEnumerable<GetAllClientesQueryResponse>))]
        [SwaggerResponse(500, "Erro interno.", typeof(string))]
        public async Task<IActionResult> GetAllClientes()
        {
            try
            {
                var clientes = await _mediator.Send(new GetAllClientesQueryRequest());

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET /cliente/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um cliente por ID", Description = "Obtém um cliente com o ID especificado.")]
        [SwaggerResponse(200, "Cliente encontrado.", typeof(GetClienteByIdQueryResponse))]
        [SwaggerResponse(400, "ID inválido.", typeof(string))]
        [SwaggerResponse(404, "Cliente não encontrado.", typeof(string))]
        public async Task<IActionResult> GetClienteById(long id)
        {
            if (id == 0)
                return BadRequest("ID inválido.");

            try
            {
                var cliente = await _mediator.Send(new GetClienteByIdQueryRequest(id));

                if (cliente == null)
                    return NotFound("Cliente não encontrado.");

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET /cliente/pesquisar?nome={nome}
        [HttpGet("pesquisar")]
        [SwaggerOperation(Summary = "Pesquisando cliente por nome", Description = "Pesquisando clientes com base no nome.")]
        [SwaggerResponse(200, "Lista de clientes encontrados.", typeof(IEnumerable<GetClienteByNomeQueryResponse>))]
        [SwaggerResponse(400, "O nome não pode ser vazio.", typeof(string))]
        [SwaggerResponse(404, "Nenhum cliente encontrado.", typeof(string))]
        public async Task<IActionResult> GetClienteByNome([FromQuery] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest("O nome não pode ser vazio.");

            try
            {
                var query = new GetClienteByNomeQueryRequest(nome);
                var clientes = await _mediator.Send(query);

                if (clientes == null || !clientes.Any())
                    return NotFound("Nenhum cliente encontrado com o nome informado.");

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
