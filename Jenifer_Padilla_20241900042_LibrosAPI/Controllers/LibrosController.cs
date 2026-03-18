using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Dtos;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Commons.Models;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibrosAppService librosAppService;

        public LibrosController(ILibrosAppService librosAppService)
        {
            this.librosAppService = librosAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLibros()
        {
            List<Libro> libros =
                await librosAppService.ObtenerLibros();

            return Ok(libros);
        }

        [HttpGet]
        [Route("ObtenerLibrosParaUsuario")]
        public async Task<IActionResult> ObtenerLibrosParaUsuario()
        {
            List<LibroDto> libroDtos =
                await librosAppService.ObtenerLibrosParaUsuario();

            return Ok(libroDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObtenerLibroPorId([FromRoute] int id)
        {
            Libro libro =
                await librosAppService.ObtenerLibroPorId(id);

            if (libro == null)
                return NotFound(new ApiResponse<Libro>
                {
                    Success = false,
                    Message = "Libro no encontrado",
                    Data = null
                });

            return Ok(libro);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarLibro(
            [FromBody] Libro libro)
        {
            var respuesta = await librosAppService.GuardarLibro(libro);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarLibro(
            [FromBody] Libro libro)
        {
            await librosAppService.ActualizarLibro(libro);
            return Ok(new ApiResponse<Libro>
            {
                Success = true,
                Message = "Libro actualizado correctamente",
                Data = libro
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> InactivarLibro([FromRoute] int id)
        {
            await librosAppService.InactivarLibro(id);
            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Registro inactivado correctamente",
                Data = null
            });
        }
    }
}