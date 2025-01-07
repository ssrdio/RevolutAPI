using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Payments.Objects
{
    public class PaymentDetailsFee
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
