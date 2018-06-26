using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Http
{
    public class HttpNorthwindClientBase
    {
        private string baseURI = "http://northwind.servicestack.net/";

        protected async Task<string> GetHttpResposeString(string relativePath)
        {
            HttpClient client = new HttpClient();
            var message = await client.GetAsync($"{baseURI}/{relativePath}");
            return await message.Content.ReadAsStringAsync();
        }

    }
}
