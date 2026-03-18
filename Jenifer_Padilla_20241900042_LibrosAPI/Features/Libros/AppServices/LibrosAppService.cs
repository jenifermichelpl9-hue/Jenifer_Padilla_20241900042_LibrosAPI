using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Commons.Models;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Dtos;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.AppServices
{
    public class LibrosAppService : ILibrosAppService
    {
        private readonly ILibroRepository libroRepository;

        public LibrosAppService(ILibroRepository libroRepository)
        {
            this.libroRepository = libroRepository;
        }

        public async Task<List<Libro>> ObtenerLibros()
        {
            return await libroRepository.ObtenerLibros();
        }

        public async Task<List<LibroDto>> ObtenerLibrosParaUsuario()
        {
            var libros = await libroRepository.ObtenerLibros();

            return libros.Select(x => new LibroDto
            {
                Nombre = x.Titulo,
                Descripcion = x.Descripcion,
                Categoria = x.Categoria?.Nombre
            }).ToList();
        }

        public async Task<Libro> ObtenerLibroPorId(int id)
        {
            return await libroRepository.ObtenerLibroPorId(id);
        }

        public async Task<ApiResponse<Libro>> GuardarLibro(Libro libro)
        {
            try
            {
                await libroRepository.GuardarLibro(libro);
                return new ApiResponse<Libro>
                {
                    Success = true,
                    Message = "Libro guardado correctamente",
                    Data = libro
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Libro>
                {
                    Success = false,
                    Message = $"Error al guardar el libro: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task ActualizarLibro(Libro libro)
        {
            await libroRepository.ActualizarLibro(libro);
        }

        public async Task InactivarLibro(int id)
        {
            await libroRepository.EliminarLibro(id);
        }
    }
}