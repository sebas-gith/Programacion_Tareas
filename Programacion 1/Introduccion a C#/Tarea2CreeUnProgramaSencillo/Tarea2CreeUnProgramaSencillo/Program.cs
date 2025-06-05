/* 
 * Sebastian Alvarez 
 * Matricula: 2024-1670
 * Fecha: 8-2-2025
 */

/* Usando los conocimientos adquiridos, 
 * usted debe desarrollar un programa que le 
 * solicite al usuario un numero y el programa indique si es par o impar
 */

Console.Write("Ingrese un numero entero: ");
try
{
    int numero = Convert.ToInt32(Console.ReadLine());

    if (numero % 2 == 0) Console.WriteLine("El numero es par");
    else Console.WriteLine("El numero es impar");

}
catch (FormatException ex)
{
    Console.WriteLine("¿No ves que dice numero entero?");
    Console.WriteLine("Vuelve a ejecutar el programa");
}catch(OverflowException ex)
{
    Console.WriteLine("El limite permitido para este numero es 2,147,483,647");
}


