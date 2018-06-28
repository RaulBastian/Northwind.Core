using Newtonsoft.Json;
using Northwind.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Http
{
    public class HttpNorthwindClientBase
    {
        private string baseURI = "http://services.odata.org/V4/Northwind/Northwind.svc";

        protected async Task<string> GetHttpResposeString(string relativePath)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");

            var message = await client.GetAsync($"{baseURI}/{relativePath}");
            return await message.Content.ReadAsStringAsync();
        }


        protected async Task<IEnumerable<T>> GetHttpTypedResponse<T>(string relativePath) where T:class
        {
            var response = await GetHttpResposeString(relativePath);
            var odata =  JsonConvert.DeserializeObject<ODataResponse<T>>(response);
            return odata.Items;
        }
    }
}
