using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Payments.Objects
{
    public class AuthenticationChallenge
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("acs_url")]
        public string AcsUrl { get; set; }
    }
}
