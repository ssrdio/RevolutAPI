using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class MerchantOrderData
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
