using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoWs.Models
{
    class WorkWithHttpClient
    {
        public string apiKey = "683erUGEb9Yr8tDYCPqyOkJ3PAWT0ImPVBJBL6dc";
        static Asteroid asteroid = new Asteroid
        {
            Name = "Eros",
            IsDangerous = false,
            OrbitingBody = "Earth",
            AverageVelocity = float.Parse("4,7"),
            AverageRadius = float.Parse("12,7"),
            FirstYear = new DateTime(1900, 12, 27),
            NextYear = new DateTime(2025, 11, 30),
            EncounterFrequency=float.Parse("7,4")
        };
        static HttpClient httpClient;
        static async Task Main(string[] args)
        {
            var asteroidJSON = JsonConvert.SerializeObject(asteroid);
            HttpContent content = new StringContent(asteroidJSON, Encoding.UTF8, "application/json");
            httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://api.nasa.gov/neo/rest/v1/feed?start_date=START_DATE&end_date=END_DATE&api_key=API_KEY");

                Console.WriteLine("Get");
                Console.WriteLine("Response");
                Console.WriteLine(response);
                Console.WriteLine("Content");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            catch (HttpRequestException hre)
            {
                //chyba
            }
        }
    }
}
