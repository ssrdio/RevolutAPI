using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class RefoundOrderRelated
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Tpye { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("amount")]
        public Amount Amount { get; set; }
    }
}
