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

                // Deserialize the JSON response to a dynamic object
                var joke = JsonSerializer.Deserialize<JsonElement>(responseBody);

                // Check if the API returned a two-part joke
                if (joke.GetProperty("type").GetString() == "twopart")
                {
                    string setup = joke.GetProperty("setup").GetString();
                    string delivery = joke.GetProperty("delivery").GetString();
                    return $"{setup} {delivery}";
                }
                else if (joke.GetProperty("type").GetString() == "single")
                {
                    string jokeText = joke.GetProperty("joke").GetString();
                    return jokeText;
                }
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