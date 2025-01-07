using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PaymentDrafts.Objects
{
    public class ChargeOptions
    {
        [JsonProperty("from")]
        public PaymentDraftsAmount From { get; set; }
        [JsonProperty("to")]
        public PaymentDraftsAmount To { get; set; }
        [JsonProperty("rate")]
        public string Rate { get; set; }
        [JsonProperty("fee")]
        public PaymentDraftsAmount Fee { get; set; }
    }
}
