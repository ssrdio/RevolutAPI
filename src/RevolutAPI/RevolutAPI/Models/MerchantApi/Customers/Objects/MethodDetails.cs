using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Customers.Objects
{
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
}
