using ECommerce.Application.Features.Produtos.Commands.Requests;
using ECommerce.Application.Features.Produtos.Queries.Requests;
using ECommerce.Application.Features.Produtos.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo produto", Description = "Cria um novo produto no sistema.")]
        [SwaggerResponse(200, "Produto criado com sucesso.", typeof(bool))]
        [SwaggerResponse(400, "Falha ao criar produto.", typeof(string))]
        public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoCommandRequest request)
        {
            if (request == null)
                return BadRequest("Dados do produto não podem ser nulos.");

            try
            {
                var result = await _mediator.Send(request);
                return result ? Ok("Produto criado com sucesso.") : BadRequest("Falha ao criar produto.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um produto", Description = "Deleta o produto com o ID especificado.")]
        [SwaggerResponse(200, "Produto deletado com sucesso.", typeof(bool))]
        [SwaggerResponse(400, "ID inválido.", typeof(string))]
        [SwaggerResponse(404, "Produto não encontrado.", typeof(string))]
        public async Task<IActionResult> DeleteProduto(long id)
        {
            if (id == 0)
                return BadRequest("ID inválido.");

            try
            {
                var result = await _mediator.Send(new DeleteProdutoCommandRequest(id));
                return result ? Ok("Produto deletado com sucesso.") : NotFound("Produto não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um produto", Description = "Atualiza os dados de um produto com o ID especificado.")]
        [SwaggerResponse(200, "Produto atualizado com sucesso.", typeof(bool))]
        [SwaggerResponse(400, "Dados inválidos para atualização.", typeof(string))]
        [SwaggerResponse(404, "Produto não encontrado para atualização.", typeof(string))]
        public async Task<IActionResult> UpdateProduto(long id, [FromBody] UpdateProdutoCommandRequest request)
        {
            if (request == null || id == 0)
                return BadRequest("Dados inválidos para atualização.");

            try
            {
                request.Id = id;
                var result = await _mediator.Send(request);
                return result ? Ok("Produto atualizado com sucesso.") : NotFound("Produto não encontrado para atualização.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os produtos", Description = "Obtém todos os produtos cadastrados.")]
        [SwaggerResponse(200, "Lista de produtos.", typeof(IEnumerable<GetAllProdutosQueryResponse>))]
        [SwaggerResponse(500, "Erro interno.", typeof(string))]
        public async Task<IActionResult> GetAllProdutos()
        {
            try
            {
                var produtos = await _mediator.Send(new GetAllProdutosQueryRequest());
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um produto por ID", Description = "Obtém um produto com o ID especificado.")]
        [SwaggerResponse(200, "Produto encontrado.", typeof(GetProdutoByIdQueryResponse))]
        [SwaggerResponse(400, "ID inválido.", typeof(string))]
        [SwaggerResponse(404, "Produto não encontrado.", typeof(string))]
        public async Task<IActionResult> GetProdutoById(long id)
        {
            if (id == 0)
                return BadRequest("ID inválido.");

            try
            {
                var produto = await _mediator.Send(new GetProdutoByIdQueryRequest(id));
                return produto == null ? NotFound("Produto não encontrado.") : Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("pesquisar")]
        [SwaggerOperation(Summary = "Pesquisando produto por nome", Description = "Pesquisando produtos com base no nome.")]
        [SwaggerResponse(200, "Lista de produtos encontrados.", typeof(IEnumerable<GetProdutoByNomeQueryResponse>))]
        [SwaggerResponse(400, "O nome não pode ser vazio.", typeof(string))]
        [SwaggerResponse(404, "Nenhum produto encontrado.", typeof(string))]
        public async Task<IActionResult> GetProdutoByNome([FromQuery] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest("O nome não pode ser vazio.");

            try
            {
                var query = new GetProdutoByNomeQueryRequest(nome);
                var produtos = await _mediator.Send(query);
                return produtos == null || !produtos.Any()
                    ? NotFound("Nenhum produto encontrado com o nome informado.")
                    : Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
