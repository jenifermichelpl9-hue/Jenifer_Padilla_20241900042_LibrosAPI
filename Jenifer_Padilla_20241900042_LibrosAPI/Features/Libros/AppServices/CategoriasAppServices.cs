using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Commons.Models;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.AppServices
{
    public class CategoriasAppService : ICategoriasAppService
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriasAppService(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            return await categoriaRepository.ObtenerCategorias();
        }

        public async Task<Categoria> ObtenerCategoriaPorId(int id)
        {
            return await categoriaRepository.ObtenerCategoriaPorId(id);
        }

        public async Task<ApiResponse<Categoria>> GuardarCategoria(Categoria categoria)
        {
            try
            {
                await categoriaRepository.GuardarCategoria(categoria);
                return new ApiResponse<Categoria>
                {
                    Success = true,
                    Message = "Categoría guardada correctamente",
                    Data = categoria
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Categoria>
                {
                    Success = false,
                    Message = $"Error al guardar la categoría: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task ActualizarCategoria(Categoria categoria)
        {
            await categoriaRepository.ActualizarCategoria(categoria);
        }

        public async Task EliminarCategoria(int id)
        {
            await categoriaRepository.EliminarCategoria(id);
        }
    }
}