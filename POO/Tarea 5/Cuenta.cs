//Sebastian Gonzalo Alvarez Concepcion          2024-1670
using System;
namespace BancoApp
{
    public class Cuenta
    {
        // Atributos de la clase
        public string NumeroCuenta { get; set; }
        public string Titular { get; set; }
        public decimal Saldo { get; private set; }

        // Constructor por defecto
        public Cuenta()
        {
            NumeroCuenta = "Sin asignar";
            Titular = "Sin asignar";
            Saldo = 0.0m;
        }

        // Constructor con parámetros
        public Cuenta(string numeroCuenta, string titular, decimal saldoInicial)
        {
            NumeroCuenta = numeroCuenta;
            Titular = titular;
            Saldo = saldoInicial >= 0 ? saldoInicial : throw new ArgumentException("El saldo inicial no puede ser negativo.");
        }

        // Método para realizar un ingreso
        public void Ingreso(decimal monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("El monto a ingresar debe ser positivo.");
                return;
            }

            Saldo += monto;
            Console.WriteLine($"Se han ingresado {monto:C}. Nuevo saldo: {Saldo:C}");
        }

        // Método para realizar un reintegro (retiro)
        public void Reintegro(decimal monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("El monto a retirar debe ser positivo.");
                return;
            }

            if (monto > Saldo)
            {
                Console.WriteLine("Fondos insuficientes para realizar el retiro.");
                return;
            }

            Saldo -= monto;
            Console.WriteLine($"Se han retirado {monto:C}. Nuevo saldo: {Saldo:C}");
        }

        // Método para realizar una transferencia
        public void Transferencia(Cuenta destino, decimal monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("El monto a transferir debe ser positivo.");
                return;
            }

            if (monto > Saldo)
            {
                Console.WriteLine("Fondos insuficientes para realizar la transferencia.");
                return;
            }

            Saldo -= monto;
            destino.Ingreso(monto);
            Console.WriteLine($"Se han transferido {monto:C} a la cuenta de {destino.Titular}. Nuevo saldo: {Saldo:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear cuentas
            Cuenta cuenta1 = new Cuenta("12345678", "Juan Pérez", 1000.00m);
            Cuenta cuenta2 = new Cuenta("87654321", "Ana López", 500.00m);

            // Mostrar saldos iniciales
            Console.WriteLine($"Saldo inicial de {cuenta1.Titular}: {cuenta1.Saldo:C}");
            Console.WriteLine($"Saldo inicial de {cuenta2.Titular}: {cuenta2.Saldo:C}");

            // Realizar operaciones
            cuenta1.Ingreso(200.00m);  // Ingresar dinero en cuenta1
            cuenta1.Reintegro(150.00m);  // Retirar dinero de cuenta1
            cuenta1.Transferencia(cuenta2, 300.00m);  // Transferir dinero de cuenta1 a cuenta2

            // Mostrar saldos finales
            Console.WriteLine($"Saldo final de {cuenta1.Titular}: {cuenta1.Saldo:C}");
            Console.WriteLine($"Saldo final de {cuenta2.Titular}: {cuenta2.Saldo:C}");
        }
    }
}
