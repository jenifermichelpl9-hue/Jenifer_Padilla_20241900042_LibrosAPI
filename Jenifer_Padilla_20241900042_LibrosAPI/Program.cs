using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Databases;
using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Repositories;
using Jenifer_Padilla_20241900042_LibrosAPI.Infraestructure.Interfaces;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.AppServices;
using Jenifer_Padilla_20241900042_LibrosAPI.Features.Libros.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configurar Entity Framework Core con SQL Server
builder.Services.AddDbContext<LibrosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibrosConnection")));

// Registrar Repositories
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

// Registrar Application Services
builder.Services.AddScoped<ILibrosAppService, LibrosAppService>();
builder.Services.AddScoped<ICategoriasAppService, CategoriasAppService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Aplicar migraciones automáticamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LibrosDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
