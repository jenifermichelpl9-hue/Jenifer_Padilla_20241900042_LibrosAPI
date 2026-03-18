using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Commons.Models;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasAppService categoriasAppService;

        public CategoriasController(ICategoriasAppService categoriasAppService)
        {
            this.categoriasAppService = categoriasAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerCategorias()
        {
            var categorias = await categoriasAppService.ObtenerCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCategoriaPorId([FromRoute] int id)
        {
            var categoria = await categoriasAppService.ObtenerCategoriaPorId(id);
            if (categoria == null)
                return NotFound(new ApiResponse<Categoria>
                {
                    Success = false,
                    Message = "Categoría no encontrada",
                    Data = null
                });

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCategoria([FromBody] Categoria categoria)
        {
            var respuesta = await categoriasAppService.GuardarCategoria(categoria);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarCategoria([FromBody] Categoria categoria)
        {
            await categoriasAppService.ActualizarCategoria(categoria);
            return Ok(new ApiResponse<Categoria>
            {
                Success = true,
                Message = "Categoría actualizada correctamente",
                Data = categoria
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCategoria([FromRoute] int id)
        {
            await categoriasAppService.EliminarCategoria(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Categoría eliminada correctamente",
                Data = null
            });
        }
    }
}
