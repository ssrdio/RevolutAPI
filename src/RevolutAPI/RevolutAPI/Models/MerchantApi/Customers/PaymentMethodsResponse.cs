using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Customers.Objects;
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

  

    
}
