using Jenifer_Padilla_20241900042_LibrosAPI.Entities;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros
{
    public class LibrosAppService
    {
        private List<Libro> libros = new List<Libro>();

        public LibrosAppService()
        {
            libros.Add(new Libro { Id = 1, Titulo = "Heartstopper Vol 6", Autor = "Alice Oseman", Anio = 2026 });
            libros.Add(new Libro { Id = 2, Titulo = "Binding 13", Autor = "Chole Walsh", Anio = 2018 });
            libros.Add(new Libro { Id = 3, Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", Anio = 1943 });
            libros.Add(new Libro { Id = 4, Titulo = "Save Me", Autor = "Mona Kasten", Anio = 2021 });
            libros.Add(new Libro { Id = 5, Titulo = "La Odisea", Autor = "Homero", Anio = -800 });
        }

        public List<Libro> ObtenerTodos()
        {
            return libros;
        }

        public Libro ObtenerPorId(int id)
        {
            return libros.FirstOrDefault(x => x.Id == id);
        }

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public void ActualizarLibro(Libro libro)
        {
            Libro? libroExiste =
                libros.Where(x => x.Id == libro.Id).FirstOrDefault();

            // En caso de no encontrarse
            if (libroExiste == null)
            {
                return;
            }

            // En caso de encontrar un registro
            libroExiste.Id = libro.Id;
            libroExiste.Titulo = libro.Titulo;
            libroExiste.Autor = libro.Autor;
            libroExiste.Anio = libro.Anio;
        }

        public void Eliminar(int id)
        {
            var libro = libros.FirstOrDefault(x => x.Id == id);

            if (libro != null)
            {
                libros.Remove(libro);
            }
        }
    }
}