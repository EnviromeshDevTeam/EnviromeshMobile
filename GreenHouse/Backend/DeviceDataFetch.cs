using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using GreenHouse.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace GreenHouse.Backend
{
    //Class fetches data returns List Chart Entries?
    //ChartEntry Types DateTime, Value, Color 
    public class DeviceDataFetch
    {
        public static readonly HttpClient client = new HttpClient();

        public async Task<RootClass> APIFetchAsync()
        {
            var responseString = await client.GetStringAsync("http://enviromesh.tech/api/TempFakeDataCall");
            RootClass Root = JsonConvert.DeserializeObject<RootClass>(responseString);

            return Root;
            //Manipulate root here or return it?
        }

       //Call Device Function to convert to chartEntries
    }
}
