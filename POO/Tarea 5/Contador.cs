//Sebastian Gonzalo Alvarez Concepcion          2024-1670
using System;

namespace ContadorApp
{
    public class Contador
    {
        // Atributo de la clase
        private int _valor;

        // Propiedad para acceder al atributo (getter y setter)
        public int Valor
        {
            get { return _valor; }
            set
            {
                _valor = value >= 0 ? value : 0; // Evitar valores negativos
            }
        }

        // Constructor por defecto
        public Contador()
        {
            _valor = 0; // Inicializa el contador en 0
        }

        // Constructor con parámetros
        public Contador(int valorInicial)
        {
            _valor = valorInicial >= 0 ? valorInicial : 0; // Evitar valores negativos
        }

        // Método para incrementar el contador
        public void Incrementar()
        {
            _valor++;
            Console.WriteLine($"El contador se incrementó a: {_valor}");
        }

        // Método para decrementar el contador
        public void Decrementar()
        {
            if (_valor > 0)
            {
                _valor--;
                Console.WriteLine($"El contador se decrementó a: {_valor}");
            }
            else
            {
                Console.WriteLine("El contador ya está en 0 y no puede ser decrecido más.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear un contador con el constructor por defecto
            Contador contador1 = new Contador();
            Console.WriteLine($"Valor inicial del contador1: {contador1.Valor}");

            // Incrementar y decrementar el contador
            contador1.Incrementar(); // Incrementa a 1
            contador1.Decrementar(); // Decrementa a 0
            contador1.Decrementar(); // Intenta decrementar más allá de 0

            // Crear un contador con el constructor con parámetros
            Contador contador2 = new Contador(5);
            Console.WriteLine($"Valor inicial del contador2: {contador2.Valor}");

            // Incrementar y decrementar el contador
            contador2.Incrementar(); // Incrementa a 6
            contador2.Decrementar(); // Decrementa a 5
        }
    }
}