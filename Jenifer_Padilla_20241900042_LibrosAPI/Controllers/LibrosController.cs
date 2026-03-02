using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LibrosController : ControllerBase
    {
        private readonly LibrosAppService librosAppService;
        public LibrosController(LibrosAppService librosAppService)
        {
            this.librosAppService = librosAppService;
        }

        // Endpoint para listar todas los libros
        [HttpGet("EnlistarLibros")]
        
        public IActionResult ObtenerTodos()
        {
            List<Libro> libros = librosAppService.ObtenerTodos();
            return Ok(libros);
        }

        // Endpoint para enlistar libros por autor
        [HttpGet]
        [Route("ListarLibrosPorAutor")]
        public IActionResult ListarLibrosPorAutor()
        {
            return Ok("Libros por autor");
        }

        // Endpoint para obtener un libro por su id
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            return Ok(librosAppService.ObtenerPorId(id));
        }

        // Endpoint para agregar un nuevo libro
        [HttpPost]
        [Route("AgregarLibro")]
       
        public IActionResult AgregarLibro([FromBody] Libro libro)
        {
            librosAppService.AgregarLibro(libro);
            return Ok("Libro agregado correctamente.");
        }

        // Endpoint para actualizar un libro existente
        [HttpPut]
        [Route("ActualizarLibro")]
        public IActionResult ActualizarLibro([FromBody] Libro libro)
        {
            librosAppService.ActualizarLibro(libro);
            return Ok("Libro agregado correctamente");
        }

        // Endpoint para borrar un libro existente
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        
        {
            librosAppService.Eliminar(id);
            return Ok("Libro eliminado correctamente");
        }
    }
}
