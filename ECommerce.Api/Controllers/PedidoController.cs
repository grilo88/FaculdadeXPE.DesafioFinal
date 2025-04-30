using ECommerce.Application.Features.Pedidos.Commands.Requests;
using ECommerce.Application.Features.Pedidos.Queries.Requests;
using ECommerce.Application.Features.Pedidos.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST /pedidos
        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo pedido", Description = "Cria um novo pedido no sistema.")]
        [SwaggerResponse(200, "Pedido criado com sucesso.", typeof(bool))]
        [SwaggerResponse(400, "Falha ao criar pedido.", typeof(string))]
        public async Task<IActionResult> CreatePedido([FromBody] CreatePedidoCommandRequest request)
        {
            if (request == null)
                return BadRequest("Dados do pedido não podem ser nulos.");

            try
            {
                var result = await _mediator.Send(request);

                if (result)
                    return Ok("Pedido criado com sucesso.");

                return BadRequest("Falha ao criar pedido.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // DELETE /pedidos/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um pedido", Description = "Deleta o pedido com o ID especificado.")]
        [SwaggerResponse(200, "Pedido deletado com sucesso.", typeof(bool))]
        [SwaggerResponse(400, "ID inválido.", typeof(string))]
        [SwaggerResponse(404, "Pedido não encontrado.", typeof(string))]
        public async Task<IActionResult> DeletePedido(long id)
        {
            if (id == 0)
                return BadRequest("ID inválido.");

            try
            {
                var result = await _mediator.Send(new DeletePedidoCommandRequest(id));

                if (result)
                    return Ok("Pedido deletado com sucesso.");

                return NotFound("Pedido não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // PUT /pedidos/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um pedido", Description = "Atualiza os dados de um pedido com o ID especificado.")]
        [SwaggerResponse(200, "Pedido atualizado com sucesso.", typeof(bool))]
        [SwaggerResponse(400, "Dados inválidos para atualização.", typeof(string))]
        [SwaggerResponse(404, "Pedido não encontrado para atualização.", typeof(string))]
        public async Task<IActionResult> UpdatePedido(long id, [FromBody] UpdatePedidoCommandRequest request)
        {
            if (request == null || id == 0)
                return BadRequest("Dados inválidos para atualização.");

            try
            {
                request.Id = id;
                var result = await _mediator.Send(request);

                if (result)
                    return Ok("Pedido atualizado com sucesso.");

                return NotFound("Pedido não encontrado para atualização.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET /pedidos
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os pedidos", Description = "Obtém todos os pedidos cadastrados.")]
        [SwaggerResponse(200, "Lista de pedidos.", typeof(IEnumerable<GetAllPedidosQueryResponse>))]
        [SwaggerResponse(500, "Erro interno.", typeof(string))]
        public async Task<IActionResult> GetAllPedidos()
        {
            try
            {
                var pedidos = await _mediator.Send(new GetAllPedidosQueryRequest());

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET /pedidos/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um pedido por ID", Description = "Obtém um pedido com o ID especificado.")]
        [SwaggerResponse(200, "Pedido encontrado.", typeof(GetPedidoByIdQueryResponse))]
        [SwaggerResponse(400, "ID inválido.", typeof(string))]
        [SwaggerResponse(404, "Pedido não encontrado.", typeof(string))]
        public async Task<IActionResult> GetPedidoById(long id)
        {
            if (id == 0)
                return BadRequest("ID inválido.");

            try
            {
                var pedido = await _mediator.Send(new GetPedidoByIdQueryRequest(id));

                if (pedido == null)
                    return NotFound("Pedido não encontrado.");

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET /pedidos/pesquisar?nome={nome}
        [HttpGet("pesquisar")]
        [SwaggerOperation(Summary = "Pesquisa pedido por nome do produto", Description = "Pesquisa pedidos com base no nome do produto.")]
        [SwaggerResponse(200, "Lista de pedidos encontrados.", typeof(IEnumerable<GetPedidosByClienteNomeQueryResponse>))]
        [SwaggerResponse(400, "O nome não pode ser vazio.", typeof(string))]
        [SwaggerResponse(404, "Nenhum pedido encontrado.", typeof(string))]
        public async Task<IActionResult> GetPedidoByNome([FromQuery] string Nome)
        {
            if (string.IsNullOrWhiteSpace(Nome))
                return BadRequest("O nome não pode ser vazio.");

            try
            {
                var query = new GetPedidosByClienteNomeQueryRequest(Nome);
                var pedidos = await _mediator.Send(query);

                if (pedidos == null || !pedidos.Any())
                    return NotFound("Nenhum pedido encontrado com o nome do produto informado.");

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
