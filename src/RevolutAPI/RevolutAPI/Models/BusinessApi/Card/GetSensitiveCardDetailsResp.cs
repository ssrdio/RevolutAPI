using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Card
{
    public class GetSensitiveCardDetailsResp
    {
        [JsonProperty("pan")]
        public string Pan { get; set; }
        [JsonProperty("cvv")]
        public string CVV { get; set; }
        [JsonProperty("expiry")]
        public string Expiry { get; set; }
    }
}
