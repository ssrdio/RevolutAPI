using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RevolutAPI.Models.Shared;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class UpdateOrderResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("public_id")]
        public string PublicId { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderTypeEnum Type { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStateEnum State { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("completed_at")]
        public DateTimeOffset CompletedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("capture_mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CaptureModeEnum CaptureMode { get; set; }

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

        [JsonProperty("refunded_amount")]
        public Amount RefundedAmount { get; set; }

        [JsonProperty("shipping_address")]
        public Address ShippingAddress { get; set; }

        [JsonProperty("payments")]
        public List<Payment> Payments { get; set; }

        [JsonProperty("related")]
        public List<Related> Related { get; set; }

        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        [JsonProperty("checkout_url")]
        public string CheckoutUrl { get; set; }

        [JsonProperty("merchant_order_uri")]
        public string MerchantOrderUri { get; set; }
    }
}
