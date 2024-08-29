using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Customers
{
    public class CustomerDetailsResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("payment_methods")]
        public List<PaymentMethodsResponse> PaymentMethods { get; set; }
    }
}
