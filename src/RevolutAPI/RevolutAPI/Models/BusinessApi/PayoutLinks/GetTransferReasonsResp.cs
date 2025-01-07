using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PayoutLinks
{
    public class GetTransferReasonsResp
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
