using Microsoft.AspNetCore.Mvc;
using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.Commands.Produtos;
using SnackGestor.Application.DTOs.Produtos;
using SnackGestor.Application.Queries.Produtos;
using SnackGestor.Infra.Abstractions;

namespace SnackGestor.Api.Controllers.Produtos
{
    [ApiController]
    [Route("api/product")]
    public class ProdutoController(ICommandDispatcher dispatcher, IQueryDispatcher queryDispatcher) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProdutoDto dto)
        {
            var produto = new CreateProductCommand
                (
                    dto.Nome,
                    dto.Preco,
                    dto.CategoriaId
                );

            await dispatcher.DispatchAsync(produto);
            return Created();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdProduct(Guid id)
        {
            Console.WriteLine($"ID recebido: {id}");

            var query = new GetByIdProductsQuery(id);

            var produto = await queryDispatcher.DispatchAsync(query);

            return Ok(produto);
        }


        [HttpGet("todos")]
        public async Task<IActionResult> GetAllProducts() 
        {
            var product = new ListarProdutosQuery();

            var result = await queryDispatcher.DispatchAsync(product);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var produto = new DeleteProductCommand(id);
            
            await dispatcher.DispatchAsync(produto);

            return NoContent();
        }
    }
}
