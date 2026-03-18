using Jenifer_Padilla_20241900042_LibrosAPI.Entities;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> ObtenerCategorias();
        Task<Categoria> ObtenerCategoriaPorId(int id);
        Task GuardarCategoria(Categoria categoria);
        Task ActualizarCategoria(Categoria categoria);
        Task EliminarCategoria(int id);
    }
}
