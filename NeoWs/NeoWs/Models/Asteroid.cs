using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace NeoWs.Models
{
    public class Asteroid
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsHazarous { get; set; }
        public string IsDangerous { get; set; }

        public string OrbitingBody => CloseApproachData?.FirstOrDefault()?.OrbitingBody ?? "Unknown";
        public string RelativeVelocity => CloseApproachData?.FirstOrDefault()?.RelativeVelocity?.KilometersPerHour ?? "Unknown";

        [JsonProperty("estimated_diameter")]
        public Diameter EstimatedDiameter { get; set; }

        [JsonProperty("close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; }
        public Color Colour { get; set; }
        public string FirstAppearance =>
        CloseApproachData?
        .Select(ca => DateTime.Parse(ca.CloseApproachDate))
        .OrderBy(date => date)
        .FirstOrDefault()
        .ToString("yyyy-MM-dd") ?? "Unknown";

        public string NextApproach =>
            CloseApproachData?
            .Select(ca => DateTime.Parse(ca.CloseApproachDate))
            .Where(date => date >= DateTime.Now)
            .OrderBy(date => date)
            .FirstOrDefault()
            .ToString("yyyy-MM-dd") ?? "No future approach";
        public double AverageFrequencyOfApproach
        {
            get
            {
                if (CloseApproachData == null || CloseApproachData.Count < 2)
                    return -1;

                var dates = CloseApproachData
                    .Select(ca => DateTime.Parse(ca.CloseApproachDate))
                    .OrderBy(date => date)
                    .ToList();

                var intervals = dates.Zip(dates.Skip(1), (prev, next) => (next - prev).TotalDays);
                return intervals.Average();
            }
        }

        public Asteroid(string name, bool isHazarous, Diameter estimatedDiameter, List<CloseApproachData> closeApproachData)
        {
            Name = name;
            IsHazarous = isHazarous;
            IsDangerous = IsHazarous ?"YES":"NO";
            EstimatedDiameter = estimatedDiameter;
            CloseApproachData = closeApproachData;
            Colour = IsHazarous ? Colors.Red : Colors.Green;
        }
    }

    public class Diameter
    {
        [JsonProperty("kilometers")]
        public DiameterValue Kilometers { get; set; }
    }

    public class DiameterValue
    {
        [JsonProperty("estimated_diameter_min")]
        public float Min { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public float Max { get; set; }
    }

    public class CloseApproachData
    {
        [JsonProperty("orbiting_body")]
        public string OrbitingBody { get; set; }
        [JsonProperty("close_approach_date")]
        public string CloseApproachDate { get; set; }

        [JsonProperty("relative_velocity")]
        public RelativeVelocity RelativeVelocity { get; set; }
    }

    public class RelativeVelocity
    {
        [JsonProperty("kilometers_per_hour")]
        public string KilometersPerHour { get; set; }
    }
}
