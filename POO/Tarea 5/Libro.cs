//Sebastian Gonzalo Alvarez Concepcion          2024-1670
using System;

namespace BibliotecaApp
{
    public class Libro
    {
        // Atributos de la clase
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AñoPublicacion { get; set; }
        public bool Prestado { get; private set; }

        // Constructor por defecto
        public Libro()
        {
            Titulo = "Sin título";
            Autor = "Anónimo";
            AñoPublicacion = 0;
            Prestado = false;
        }

        // Constructor con parámetros
        public Libro(string titulo, string autor, int añoPublicacion)
        {
            Titulo = titulo;
            Autor = autor;
            AñoPublicacion = añoPublicacion;
            Prestado = false; // Por defecto el libro no está prestado
        }

        // Método para prestar un libro
        public void Prestamo()
        {
            if (Prestado)
            {
                Console.WriteLine($"El libro \"{Titulo}\" ya está prestado.");
            }
            else
            {
                Prestado = true;
                Console.WriteLine($"El libro \"{Titulo}\" ha sido prestado.");
            }
        }

        // Método para devolver un libro
        public void Devolucion()
        {
            if (!Prestado)
            {
                Console.WriteLine($"El libro \"{Titulo}\" no estaba prestado.");
            }
            else
            {
                Prestado = false;
                Console.WriteLine($"El libro \"{Titulo}\" ha sido devuelto.");
            }
        }

        // Método ToString para mostrar información del libro
        public override string ToString()
        {
            return $"Título: {Titulo}, Autor: {Autor}, Año de Publicación: {AñoPublicacion}, Prestado: {(Prestado ? "Sí" : "No")}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear un libro con el constructor por defecto
            Libro libro1 = new Libro();
            Console.WriteLine(libro1.ToString());

            // Crear un libro con el constructor con parámetros
            Libro libro2 = new Libro("1984", "George Orwell", 1949);
            Console.WriteLine(libro2.ToString());

            // Realizar préstamo y devolución
            libro2.Prestamo(); // Prestar el libro
            Console.WriteLine(libro2.ToString());
            libro2.Prestamo(); // Intentar prestarlo de nuevo
            libro2.Devolucion(); // Devolver el libro
            Console.WriteLine(libro2.ToString());
            libro2.Devolucion(); // Intentar devolverlo de nuevo
        }
    }
}