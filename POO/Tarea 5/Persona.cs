//Sebastian Gonzalo Alvarez Concepcion          2024-1670
using System;
namespace Personas
{
    public class Persona
    {
        // Atributos de la clase
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public bool Casado { get; set; }
        public string NumeroDocumentoIdentidad { get; set; }

        // Constructor de la clase
        public Persona(string nombre, string apellidos, int edad, bool casado, string numeroDocumentoIdentidad)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Casado = casado;
            NumeroDocumentoIdentidad = numeroDocumentoIdentidad;
        }

        // Métodos (acciones según profesión)
        public void Programar()
        {
            Console.WriteLine($"{Nombre} {Apellidos} está programando un software.");
        }

        public void Enseñar()
        {
            Console.WriteLine($"{Nombre} {Apellidos} está enseñando matemáticas a sus estudiantes.");
        }

        public void Diseñar()
        {
            Console.WriteLine($"{Nombre} {Apellidos} está diseñando un logotipo creativo.");
        }

        public void Operar()
        {
            Console.WriteLine($"{Nombre} {Apellidos} está realizando una cirugía importante.");
        }

        public void Cocinar()
        {
            Console.WriteLine($"{Nombre} {Apellidos} está preparando una comida deliciosa.");
        }

        public void Construir()
        {
            Console.WriteLine($"{Nombre} {Apellidos} está construyendo una casa.");
        }

        public void Pintar()
        {
            Console.WriteLine($"{Nombre} {Apellidos} está pintando un paisaje hermoso.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creación de 7 objetos Persona con profesiones diferentes
            Persona programador = new Persona("Luis", "Gómez", 30, false, "12345678");
            Persona maestro = new Persona("María", "Pérez", 40, true, "87654321");
            Persona diseñador = new Persona("Carlos", "Ramírez", 28, false, "11223344");
            Persona doctor = new Persona("Ana", "Torres", 35, true, "22334455");
            Persona chef = new Persona("Jorge", "Hernández", 45, true, "33445566");
            Persona albañil = new Persona("Pedro", "Martínez", 50, false, "44556677");
            Persona pintor = new Persona("Sofía", "López", 25, false, "55667788");

            // Llamando a las acciones de cada persona
            programador.Programar();
            maestro.Enseñar();
            diseñador.Diseñar();
            doctor.Operar();
            chef.Cocinar();
            albañil.Construir();
            pintor.Pintar();
        }
    }
}
