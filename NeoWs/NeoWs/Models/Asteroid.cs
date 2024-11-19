using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace NeoWs.Models
{
    internal class Asteroid
    {
        public string Name {  get; set; }
        public bool IsDangerous { get; set; }
        public string OrbitingBody {  get; set; }
        public float AverageVelocity { get; set; }
        public float AverageRadius { get; set; }
        public DateTime FirstYear { get; set; }
        public DateTime NextYear { get; set; }
        public float EncounterFrequency { get; set; }
        public override string ToString()
        {
            return $"{Name}:{IsDangerous}:{OrbitingBody}:{AverageVelocity}:{AverageRadius}:{FirstYear}:{NextYear}:{EncounterFrequency}";
        }
    }
}
