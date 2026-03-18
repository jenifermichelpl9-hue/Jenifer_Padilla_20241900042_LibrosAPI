using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Databases;
using Microsoft.EntityFrameworkCore;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly LibrosDbContext dbContext;

        public LibroRepository(LibrosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Libro>> ObtenerLibros()
        {
            return await dbContext.Libros
                .Where(x => x.Activo)
                .Include(x => x.Categoria)
                .ToListAsync();
        }

        public async Task<Libro> ObtenerLibroPorId(int id)
        {
            return await dbContext.Libros
                .Where(x => x.Id == id && x.Activo)
                .Include(x => x.Categoria)
                .FirstOrDefaultAsync();
        }

        public async Task GuardarLibro(Libro libro)
        {
            libro.Activo = true;
            libro.FechaAgrega = DateTime.Now;
            await dbContext.Libros.AddAsync(libro);
            await dbContext.SaveChangesAsync();
        }

        public async Task ActualizarLibro(Libro libro)
        {
            var libroExistente = await dbContext.Libros.FirstOrDefaultAsync(x => x.Id == libro.Id);

            if (libroExistente != null)
            {
                libroExistente.Titulo = libro.Titulo;
                libroExistente.Autor = libro.Autor;
                libroExistente.Descripcion = libro.Descripcion;
                libroExistente.FechaPublicacion = libro.FechaPublicacion;
                libroExistente.CategoriaId = libro.CategoriaId;

                dbContext.Libros.Update(libroExistente);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task EliminarLibro(int id)
        {
            var libro = await dbContext.Libros.FirstOrDefaultAsync(x => x.Id == id);

            if (libro != null)
            {
                libro.Activo = false;
                dbContext.Libros.Update(libro);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
