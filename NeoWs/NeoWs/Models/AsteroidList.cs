using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace NeoWs.Models
{
    class AsteroidList
    {
        public static string ApiKey = "";
        [JsonProperty("near_earth_objects ")]
        public List<Asteroid> asteroidsList { get; set; } = new List<Asteroid>();

        public AsteroidList() => LoadAsteroids();

        public async Task LoadAsteroids()
        {
            string NeoWsUrl = "https://api.nasa.gov/neo/rest/v1/feed";
            string startDate = DateTime.Now.ToString("yyyy-MM-dd");
            string endDate = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            string url = $"{NeoWsUrl}?start_date={startDate}&end_date={endDate}&api_key={ApiKey}";
            asteroidsList.Clear();
            using HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var asteroidData = JsonConvert.DeserializeObject<NeoWsResponse>(response);

            var asteroids = asteroidData.NearEarthObjects
                    .SelectMany(kvp => kvp.Value)
                    .ToList();
            foreach (var item in asteroids)
            {
                asteroidsList.Add(item);
            }
        }
    }
    public class NeoWsResponse
    {
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, List<Asteroid>> NearEarthObjects { get; set; }
    }
}