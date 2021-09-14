using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GreenHouse
{
    public class ApiServices
    {
        public async Task LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username",userName),
                new KeyValuePair<string, string>("passWord",password),
            };
            
            var request = new HttpRequestMessage(HttpMethod.Post, "http://enviromesh.tech/login/token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            Debug.WriteLine(content);
        }
    }
}
