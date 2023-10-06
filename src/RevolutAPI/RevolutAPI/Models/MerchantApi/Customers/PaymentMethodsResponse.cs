using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Customers
{
    public class PaymentMethodsResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("saved_for")]
        public string SavedFor { get; set; }
        [JsonProperty("method_details")]
        public MethodDetails MethodDetails { get; set; }
    }

    public class MethodDetails
    {
        [JsonProperty("bin")]
        public string Bin { get; set; }
        [JsonProperty("last4")]
        public string Last4 { get; set; }
        [JsonProperty("expiry_month")]
        public int ExpiryMonth { get; set; }
        [JsonProperty("expiry_year")]
        public int ExpiryYear { get; set; }
        [JsonProperty("cardholder_name")]
        public string CardholderName { get; set; }
        [JsonProperty("billing_address")]
        public BillingAddress BillingAddress { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("funding")]
        public string Funding { get; set; }
        [JsonProperty("issuer")]
        public string Issuer { get; set; }
        [JsonProperty("issuer_country")]
        public string IssuerCountry { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class BillingAddress
    {
        [JsonProperty("street_line_1")]
        public string StreetLine1 { get; set; }
        [JsonProperty("street_line_2")]
        public string StreetLine2 { get; set;}
        [JsonProperty("post_code")]
        public string PostCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
