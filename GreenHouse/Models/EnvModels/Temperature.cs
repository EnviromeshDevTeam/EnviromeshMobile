using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenHouse.Models.EnvModels
{
    class Temperature
    {
        // TODO: WE convert all EnvModels to inherit from one superclass? Saves alot of this code?
        [JsonProperty("1H")]
        public List<Dictionary<DateTime, float>> _1H { get; set; }

        [JsonProperty("4H")]
        public List<Dictionary<DateTime, float>> _4H { get; set; }

        [JsonProperty("12H")]
        public List<Dictionary<DateTime, float>> _12H { get; set; }

        [JsonProperty("24H")]
        public List<Dictionary<DateTime, float>> _24H { get; set; }

        [JsonProperty("6D")]
        public List<Dictionary<DateTime, float>> _6D { get; set; }

        [JsonProperty("30D")]
        public List<Dictionary<DateTime, float>> _30D { get; set; }
    }
}
