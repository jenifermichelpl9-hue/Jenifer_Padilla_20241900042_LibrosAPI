namespace Jenifer_Padilla_20241900042_LibrosAPI.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; } = true;

        public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
