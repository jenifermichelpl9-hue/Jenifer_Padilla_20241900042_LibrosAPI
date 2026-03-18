using Jenifer_Padilla_20241900042_LibrosAPI.Entities;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<Libro>> ObtenerLibros();
        Task<Libro> ObtenerLibroPorId(int id);
        Task GuardarLibro(Libro libro);
        Task ActualizarLibro(Libro libro);
        Task EliminarLibro(int id);
    }
}