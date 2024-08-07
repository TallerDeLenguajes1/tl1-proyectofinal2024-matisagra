using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api
{
    public class ChistesProgramadores
    {
        public static async Task<string> Chistes()
        {
            string url = "https://v2.jokeapi.dev/joke/Programming,Christmas?lang=es";

            try
            {
                HttpClient client = new HttpClient();
                
                HttpResponseMessage response = await client.GetAsync(url);
                
                response.EnsureSuccessStatusCode();
                
                string responseBody = await response.Content.ReadAsStringAsync();

                var joke = JsonSerializer.Deserialize<JsonElement>(responseBody);

                // Verificar si la API devolvió un chiste de dos partes
                if (joke.GetProperty("type").GetString() == "twopart")
                {
                    // Obtener y combinar las dos partes del chiste
                    string setup = joke.GetProperty("setup").GetString();
                    string delivery = joke.GetProperty("delivery").GetString();
                    return $"{setup} {delivery}";
                }
                // Verificar si la API devolvió un chiste de una sola parte
                else if (joke.GetProperty("type").GetString() == "single")
                {
                    // Obtener el chiste
                    string jokeText = joke.GetProperty("joke").GetString();
                    return jokeText;
                }
                // Manejar el caso en que el tipo de chiste no es soportado
                else
                {
                    throw new NotSupportedException("Tipo de chiste no soportado.");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                
                throw e;
            }
        }
    }
}
