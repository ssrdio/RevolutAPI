using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class RefundOrderReq
    {
        [JsonIgnore]
        public double Amount { get; set; }

        [JsonProperty("amount")]
        public long InternalAmount
        {
            get
            {
                return Convert.ToInt64(Amount * 100);
            }
        }
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("merchant_order_ext_ref", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantOrderExtRef { get; set; }
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Metadata { get; set; }

        public RefundOrderReq(double amount,
            string description = null,
            string merchantOrderExtRef = null,
            Dictionary<string, string> metadata = null)
        {
            Amount = amount;
            Description = description;
            MerchantOrderExtRef = merchantOrderExtRef;
            Metadata = metadata;
        }
    }
}
