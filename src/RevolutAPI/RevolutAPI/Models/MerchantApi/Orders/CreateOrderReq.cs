using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class CreateOrderReq
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

        [JsonProperty("capture_mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CaptureModeEnum CaptureMode { get; set; }

        [JsonProperty("merchant_order_ext_ref")]
        public string MerchantOrderExtRef { get; set; }

        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("settlement_currency")]
        public string SettlementCurrency { get; set; }

        [JsonProperty("merchant_customer_ext_ref")]
        public string MerchantCustomerExtRef { get; set; }
    }
}
