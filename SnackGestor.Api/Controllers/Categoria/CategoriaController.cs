using Microsoft.AspNetCore.Mvc;
using SnackGestor.Application.Abstractions.Messaging;
using SnackGestor.Application.Commands.Categorias;
using SnackGestor.Application.DTOs.Categorias;

namespace SnackGestor.Api.Controllers.Categoria
{
    [ApiController]
    [Route("api/category")]
    public class CategoriaController(ICommandDispatcher dispatcher) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
        {
            var category = new CreateCategoryCommand(dto.Name);

            await dispatcher.DispatchAsync(category);

            return Ok(category);
        }
    }
}
