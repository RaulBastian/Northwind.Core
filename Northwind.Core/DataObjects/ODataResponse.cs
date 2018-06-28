using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.DataObjects
{
    public class ODataResponse<T>
    {
        [JsonProperty("odata.context")]
        public string Context { get; set; }

        [JsonProperty("odata.nextLink")]
        public string NextLink { get; set; }

        [JsonProperty("value")]
        public IEnumerable<T> Items { get; set; }
    }
}
