-- Crear base de datos
CREATE DATABASE LibrosDB;
GO

USE LibrosDB;
GO

-- TABLA CATEGORIAS (debe crearse PRIMERO)
CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(250) NOT NULL,
    Activo BIT DEFAULT 1
);
GO

-- TABLA LIBROS
CREATE TABLE Libros (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Titulo VARCHAR(250) NOT NULL,
    Autor VARCHAR(250) NOT NULL,
    Descripcion VARCHAR(MAX) NULL,
    FechaPublicacion DATETIME NULL,
    CategoriaId INT NOT NULL,
    Activo BIT DEFAULT 1,
    FechaAgrega DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Libros_Categorias FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);
GO

-- Insertar categorías de ejemplo
INSERT INTO Categorias (Nombre, Activo)
VALUES
('Realismo mágico', 1),
('Literatura infantil', 1),
('Clásicos de aventura', 1);
GO

-- Insertar libros con sus categorías
INSERT INTO Libros (Titulo, Autor, Descripcion, FechaPublicacion, CategoriaId)
VALUES
('Cien años de soledad', 'Gabriel García Márquez', 'Una epopeya de realismo mágico', '1967-05-30', 1),
('El principito', 'Antoine de Saint-Exupéry', 'Una fábula poética para todas las edades', '1943-04-06', 2),
('Don Quijote de la Mancha', 'Miguel de Cervantes', 'Las aventuras del caballero andante', '1605-01-16', 3);
GO