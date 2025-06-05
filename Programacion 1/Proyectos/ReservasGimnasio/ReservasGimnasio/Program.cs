using Microsoft.Data.SqlClient;
using ReservasGimnasio.Models;
using ReservasGimnasio.Views;

namespace ReservasGimnasio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuView.MostrarMenuPrincipal();
            int opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1){ 
                            
            }
        }
    }
}