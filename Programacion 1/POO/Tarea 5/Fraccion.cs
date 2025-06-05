//Sebastian Gonzalo Alvarez Concepcion          2024-1670
using System;

namespace FraccionesApp
{
    public class Fraccion
    {
        // Atributos: numerador y denominador
        public int Numerador { get; set; }
        public int Denominador { get; set; }

        // Constructor por defecto
        public Fraccion()
        {
            Numerador = 0;
            Denominador = 1; // El denominador no puede ser 0
        }

        // Constructor con parámetros
        public Fraccion(int numerador, int denominador)
        {
            if (denominador == 0)
                throw new ArgumentException("El denominador no puede ser 0.");
            Numerador = numerador;
            Denominador = denominador;
            Simplificar(); // Simplifica la fracción automáticamente
        }

        // Método para sumar dos fracciones
        public Fraccion Sumar(Fraccion otra)
        {
            int nuevoNumerador = (Numerador * otra.Denominador) + (otra.Numerador * Denominador);
            int nuevoDenominador = Denominador * otra.Denominador;
            return new Fraccion(nuevoNumerador, nuevoDenominador);
        }

        // Método para restar dos fracciones
        public Fraccion Restar(Fraccion otra)
        {
            int nuevoNumerador = (Numerador * otra.Denominador) - (otra.Numerador * Denominador);
            int nuevoDenominador = Denominador * otra.Denominador;
            return new Fraccion(nuevoNumerador, nuevoDenominador);
        }

        // Método para multiplicar dos fracciones
        public Fraccion Multiplicar(Fraccion otra)
        {
            int nuevoNumerador = Numerador * otra.Numerador;
            int nuevoDenominador = Denominador * otra.Denominador;
            return new Fraccion(nuevoNumerador, nuevoDenominador);
        }

        // Método para dividir dos fracciones
        public Fraccion Dividir(Fraccion otra)
        {
            if (otra.Numerador == 0)
                throw new DivideByZeroException("No se puede dividir por una fracción con numerador 0.");
            int nuevoNumerador = Numerador * otra.Denominador;
            int nuevoDenominador = Denominador * otra.Numerador;
            return new Fraccion(nuevoNumerador, nuevoDenominador);
        }

        // Método para simplificar la fracción
        private void Simplificar()
        {
            int mcd = MCD(Numerador, Denominador);
            Numerador /= mcd;
            Denominador /= mcd;

            // Asegurarse de que el denominador siempre sea positivo
            if (Denominador < 0)
            {
                Numerador = -Numerador;
                Denominador = -Denominador;
            }
        }

        // Método para calcular el Máximo Común Divisor (MCD)
        private int MCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Método ToString para mostrar la fracción
        public override string ToString()
        {
            return $"{Numerador}/{Denominador}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear dos fracciones
            Fraccion fraccion1 = new Fraccion(3, 4); // 3/4
            Fraccion fraccion2 = new Fraccion(2, 5); // 2/5

            // Mostrar las fracciones iniciales
            Console.WriteLine($"Fracción 1: {fraccion1}");
            Console.WriteLine($"Fracción 2: {fraccion2}");

            // Operaciones
            Fraccion suma = fraccion1.Sumar(fraccion2);
            Console.WriteLine($"Suma: {suma}");

            Fraccion resta = fraccion1.Restar(fraccion2);
            Console.WriteLine($"Resta: {resta}");

            Fraccion multiplicacion = fraccion1.Multiplicar(fraccion2);
            Console.WriteLine($"Multiplicación: {multiplicacion}");

            Fraccion division = fraccion1.Dividir(fraccion2);
            Console.WriteLine($"División: {division}");
        }
    }
}
