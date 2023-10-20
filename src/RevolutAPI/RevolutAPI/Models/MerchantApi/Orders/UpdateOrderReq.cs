using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RevolutAPI.Models.Shared;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class UpdateOrderReq
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
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("merchant_order_ext_ref")]
        public string MerchantOrderExtRef { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("capture_mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CaptureModeEnum CaptureMode { get; set; }

        [JsonProperty("settlement_currency")]
        public string SettlementCurrency { get; set; } 

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("metadata")]
        public string Metadata { get; set; }

        [JsonProperty("enforce_challenge")]
        public string EnforceChallenge { get; set; }
    }
}
