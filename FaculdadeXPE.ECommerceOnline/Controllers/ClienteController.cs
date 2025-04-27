using FaculdadeXPE.ECommerceOnline.Application.Features.Clientes.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FaculdadeXPE.ECommerceOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        // POST /cliente
        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteCommandRequest request)
        {
            if (request == null)
            {
                return BadRequest("Dados do cliente não podem ser nulos.");
            }

            try
            {
                // Envia o comando para o MediatR, que invoca o CreateClienteCommandHandler
                var result = await _mediator.Send(request);

                if (result)
                {
                    return Ok("Cliente criado com sucesso.");
                }

                return BadRequest("Falha ao criar cliente.");
            }
            catch (Exception ex)
            {
                // Tratamento de erro
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
