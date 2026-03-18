using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Databases;
using Microsoft.EntityFrameworkCore;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly LibrosDbContext dbContext;

        public CategoriaRepository(LibrosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await dbContext.Categorias
                .Where(x => x.Activo)
                .ToListAsync();
        }

        public async Task<Categoria> ObtenerCategoriaPorId(int id)
        {
            return await dbContext.Categorias
                .Where(x => x.Id == id && x.Activo)
                .FirstOrDefaultAsync();
        }

        public async Task GuardarCategoria(Categoria categoria)
        {
            categoria.Activo = true;
            await dbContext.Categorias.AddAsync(categoria);
            await dbContext.SaveChangesAsync();
        }

        public async Task ActualizarCategoria(Categoria categoria)
        {
            var categoriaExistente = await dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == categoria.Id);

            if (categoriaExistente != null)
            {
                categoriaExistente.Nombre = categoria.Nombre;
                dbContext.Categorias.Update(categoriaExistente);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task EliminarCategoria(int id)
        {
            var categoria = await dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (categoria != null)
            {
                categoria.Activo = false;
                dbContext.Categorias.Update(categoria);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
