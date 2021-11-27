using GreenHouse.Models.EnvModels;
using Microcharts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenHouse.Models
{
    /// <summary>
    /// Scalable, There may be multiple devices in JSON API
    /// </summary>
    public class Device
    {
        [JsonProperty("Temperature")]
        public Temperature Temperature { get; set; }

        [JsonProperty("Humidity")]
        public Humidity Humidity { get; set; }

        [JsonProperty("CO2")]
        public CO2 CO2 { get; set; }

        [JsonProperty("TVOC")]
        public TVOC TVOC { get; set; }

        [JsonProperty("Moisture")]
        public Moisture Moisture { get; set; }
      
    }
}
