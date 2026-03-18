namespace Jenifer_Padilla_20241900042_LibrosAPI.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public int CategoriaId { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaAgrega { get; set; } = DateTime.Now;

        public virtual Categoria? Categoria { get; set; }
    }
}
