using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumeApi
{
    class Program
    {

        public static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hola");
            Console.Clear();
            Console.WriteLine("Buscando...");
            await getPokemon("ditto");
            Console.WriteLine("que tal");
        }

        public static async Task getPokemon(string pokemon)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/{pokemon}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseString = await response.Content.ReadAsStringAsync();

                Console.Write(responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an exception \n{ex.Message}");
            }

        }
    }
}