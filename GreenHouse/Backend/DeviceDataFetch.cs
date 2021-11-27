using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using GreenHouse.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using GreenHouse.Logging;
using Xamarin.Forms;

namespace GreenHouse.Backend
{
    //Class fetches data returns List Chart Entries?
    //ChartEntry Types DateTime, Value, Color 

    /// <summary>
    /// Initiate HTTP Fetch and Deserialize into ROot
    /// </summary>
    public class DeviceDataFetch
    {
        public static readonly HttpClient client = new HttpClient();


        public async Task<RootClass> APIFetchAsync()
        {

            var responseString = await client.GetStringAsync("http://enviromesh.tech/api/TempFakeDataCall");
            RootClass Root = JsonConvert.DeserializeObject<RootClass>(responseString);
            DependencyService.Get<IXamarinLog>().Warning(this, "Attempting to Fetch API + Deserialize");
            return Root;
            //Manipulate root here or return it?
        }

       //Call Device Function to convert to chartEntries
    }
}
