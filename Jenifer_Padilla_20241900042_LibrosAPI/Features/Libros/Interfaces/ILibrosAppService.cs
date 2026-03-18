using Jenifer_Padilla_20241900042_LibrosAPI.Commons.Models;
using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Dtos;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Interfaces
{
    public interface ILibrosAppService
    {
        Task<List<Libro>> ObtenerLibros();
        Task<ApiResponse<Libro>> GuardarLibro(Libro libro);
        Task ActualizarLibro(Libro libro);
        Task<Libro> ObtenerLibroPorId(int id);
        Task InactivarLibro(int id);
        Task<List<LibroDto>> ObtenerLibrosParaUsuario();
    }
}