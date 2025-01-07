
using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Orders.Objects;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class CreateOrderResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("capture_mode")]
        public string CaptureMode { get; set; }

        [JsonProperty("cancel_authorised_after")]
        public string CancelAuthorisedAfter { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("outstanding_amount")]
        public int OutstandingAmount { get; set; }

        [JsonProperty("refunded_amount")]
        public int RefundedAmount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("settlement_currency")]
        public string SettlementCurrency { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("payments")]
        public List<OrderPayment> Payments { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("industry_data", NullValueHandling = NullValueHandling.Ignore)]
        public IndustryData IndustryData { get; set; }

        [JsonProperty("merchant_order_data", NullValueHandling = NullValueHandling.Ignore)]
        public MerchantOrderData MerchantOrderData { get; set; }

        [JsonProperty("upcoming_payment_data", NullValueHandling = NullValueHandling.Ignore)]
        public UpcomingPaymentData UpcomingPaymentData { get; set; }

        [JsonProperty("checkout_url")]
        public string CheckoutUrl { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("shipping", NullValueHandling = NullValueHandling.Ignore)]
        public Shipping Shipping { get; set; }

        [JsonProperty("enforce_challenge")]
        public string EnforceChallenge { get; set; }

        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; }

    }
}
