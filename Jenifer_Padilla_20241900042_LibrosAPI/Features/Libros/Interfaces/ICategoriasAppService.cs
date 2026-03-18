using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Jenifer_Padilla_20241900042_LibrosAPI.Commons.Models;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Interfaces
{
    public interface ICategoriasAppService
    {
        Task<List<Categoria>> ObtenerCategorias();
        Task<Categoria> ObtenerCategoriaPorId(int id);
        Task<ApiResponse<Categoria>> GuardarCategoria(Categoria categoria);
        Task ActualizarCategoria(Categoria categoria);
        Task EliminarCategoria(int id);
    }
}