using Newtonsoft.Json;
using System;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class OrderResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("public_id")]
        public string PublicId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("completed_at")]
        public DateTimeOffset CompletedAt { get; set; }

        [JsonProperty("order_amount")]
        public Amount OrderAmount { get; set; }

        [JsonProperty("merchant_order_ext_ref")]
        public string MerchantOrderExtRef { get; set; }

        [JsonProperty("merchant_customer_ext_ref")]
        public string MerchantCustomerExtRef { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("settled_amount")]
        public Amount SettledAmount { get; set; }

        [JsonProperty("refunded_amount")]
        public Amount RefundedAmount { get; set; }

        [JsonProperty("fees")]
        public Fee[] Fees { get; set; }

        [JsonProperty("payments")]
        public Payment[] Payments { get; set; }

        [JsonProperty("attempts")]
        public Attempt[] Attempts { get; set; }

        [JsonProperty("related")]
        public Attempt[] Related { get; set; }

        [JsonProperty("shipping_address")]
        public IngAddress ShippingAddress { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public partial class Attempt
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }
    }

    public partial class Amount
    {
        [JsonProperty("value")]
        internal long InternalValue { get; set; }
        [JsonIgnore]
        public double Value { get { return InternalValue / 100d; } }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public partial class Fee
    {
        [JsonProperty("value")]
        internal long InternalValue { get; set; }

        [JsonIgnore]
        public double Value { get { return InternalValue / 100d; } }


        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Payment
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("completed_at")]
        public DateTimeOffset CompletedAt { get; set; }

        [JsonProperty("card")]
        public Card Card { get; set; }
    }

    public partial class Card
    {
        [JsonProperty("card_type")]
        public string CardType { get; set; }

        [JsonProperty("funding")]
        public string Funding { get; set; }

        [JsonProperty("card_bin")]
        public string CardBin { get; set; }

        [JsonProperty("card_last_four")]
        public string CardLastFour { get; set; }

        [JsonProperty("card_expiry")]
        public string CardExpiry { get; set; }

        [JsonProperty("cardholder_name")]
        public string CardholderName { get; set; }

        [JsonProperty("checks")]
        public Checks Checks { get; set; }

        [JsonProperty("risk_level")]
        public string RiskLevel { get; set; }

        [JsonProperty("billing_address")]
        public IngAddress BillingAddress { get; set; }
    }

    public partial class IngAddress
    {
        [JsonProperty("street_line_1")]
        public string StreetLine1 { get; set; }

        [JsonProperty("street_line_2")]
        public string StreetLine2 { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }
    }

    public partial class Checks
    {
        [JsonProperty("three_ds")]
        public ThreeDs ThreeDs { get; set; }

        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }

        [JsonProperty("cvv_verification")]
        public string CvvVerification { get; set; }
    }

    public partial class ThreeDs
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }
    }
}
