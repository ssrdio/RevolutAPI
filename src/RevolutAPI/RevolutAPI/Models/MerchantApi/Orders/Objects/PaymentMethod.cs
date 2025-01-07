using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class PaymentMethod
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("card_brand")]
        public string CardBrand { get; set; }
        [JsonProperty("funding")]
        public string Funding { get; set; }
        [JsonProperty("card_country_code")]
        public string CardCountryCode { get; set; }
        [JsonProperty("card_bin")]
        public string CardBin { get; set; }
        [JsonProperty("card_last_for")]
        public string CardLastFor { get; set; }
        [JsonProperty("card_expiry")]
        public string CardExpiry { get; set; }
        [JsonProperty("cardholder_name")]
        public string CardholderName { get; set; }
        [JsonProperty("checks")]
        public Checks Checks { get; set; }
    }
}
