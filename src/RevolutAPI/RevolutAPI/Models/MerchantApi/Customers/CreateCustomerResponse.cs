using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Customers
{
    public class CreateCustomerResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("full_name")]
        public string Full_name { get; set; }
        [JsonProperty("business_name")]
        public string BusinessName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get;set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
    }
}
