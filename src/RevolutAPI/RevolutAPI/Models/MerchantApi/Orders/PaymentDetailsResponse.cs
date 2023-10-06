using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class PaymentDetailsResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
