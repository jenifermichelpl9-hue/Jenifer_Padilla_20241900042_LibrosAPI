using Jenifer_Padilla_20241900042_LibrosAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Databases
{
    public class LibrosDbContext : DbContext
    {
        public LibrosDbContext(DbContextOptions<LibrosDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Libro> Libros => Set<Libro>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categorias");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.Nombre)
                    .HasColumnType("VARCHAR(250)")
                    .IsRequired();

                entity.Property(x => x.Activo)
                    .HasColumnType("BIT")
                    .HasDefaultValue(true);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("Libros");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(x => x.Titulo)
                    .HasColumnType("VARCHAR(250)")
                    .IsRequired();

                entity.Property(x => x.Autor)
                    .HasColumnType("VARCHAR(250)")
                    .IsRequired();

                entity.Property(x => x.Descripcion)
                    .HasColumnType("VARCHAR(MAX)");

                entity.Property(x => x.FechaPublicacion)
                    .HasColumnType("DATETIME");

                entity.Property(x => x.CategoriaId)
                    .IsRequired();

                entity.Property(x => x.Activo)
                    .HasColumnType("BIT")
                    .HasDefaultValue(true);

                entity.Property(x => x.FechaAgrega)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("GETDATE()");

                entity.HasOne(x => x.Categoria)
                    .WithMany(x => x.Libros)
                    .HasForeignKey(x => x.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}