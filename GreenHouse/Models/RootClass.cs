using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenHouse.Models
{
    public class RootClass
    {
        //Scales for multiple devices

         [JsonProperty("Devices")]
        public List<Device> Devices { get; set; }


    }
}
