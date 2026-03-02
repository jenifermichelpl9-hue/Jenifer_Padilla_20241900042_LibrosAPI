namespace Jenifer_Padilla_20241900042_LibrosAPI.Entities
{
    public class LibrosDomainService
    {
        public LibrosDomainService() { }

        /// <summary>
        /// Validaciones al momento de agregar un nuevo libro
        /// </summary>
        /// <param name="libro"></param>
        public bool AgregarLibro(Libro libro)
        {
            if (string.IsNullOrEmpty(libro.Titulo) ||
                string.IsNullOrEmpty(libro.Autor))
            {
                return false;
            }

            return true;
        }
    }
}

