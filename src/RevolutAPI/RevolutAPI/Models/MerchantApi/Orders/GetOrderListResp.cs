using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class GetOrderListResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("completed_at")]
        public DateTime CompletedAt { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("capture_mode")]
        public string CaptureMode { get; set; }
        [JsonProperty("settlement_currency")]
        public string SettlementCurrency { get; set; }
        [JsonProperty("merchant_order_ext_ref")]
        public string MerchantOrderExtRef { get; set; }
        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("order_amount")]
        public Amount OrderAmount { get; set; }
        [JsonProperty("order_outstanding_amount")]
        public Amount OrderOutstandingAmount { get; set; }
        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

    }
}
