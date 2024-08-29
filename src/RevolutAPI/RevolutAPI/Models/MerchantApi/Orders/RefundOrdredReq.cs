using Newtonsoft.Json;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class RefundOrdredReq
    {

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("merchant_customer_ext_ref")]
        public string MerchantCustomerExtRef { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
