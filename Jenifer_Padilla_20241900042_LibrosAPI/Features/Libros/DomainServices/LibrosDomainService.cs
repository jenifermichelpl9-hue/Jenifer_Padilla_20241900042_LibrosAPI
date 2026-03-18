using Jenifer_Padilla_20241900042_LibrosAPI.Entities;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.DomainServices
{
    public class LibrosDomainService
    {
        public LibrosDomainService() { }

        public bool ValidarLibro(Libro libro)
        {
            if (libro == null)
                return false;

            if (string.IsNullOrEmpty(libro.Titulo))
                return false;

            if (string.IsNullOrEmpty(libro.Autor))
                return false;

            if (libro.CategoriaId <= 0)
                return false;

            return true;
        }
    }
}