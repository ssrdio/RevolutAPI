using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Customers
{
    public class UpdateCustomerRequest
    {
        [JsonProperty("full_name",NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }
        [JsonProperty("business_name",NullValueHandling = NullValueHandling.Ignore)]
        public string BusinessName { get; set; }
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        public UpdateCustomerRequest(string fullName = null, string businessName = null, string email = null, string phone = null)
        {
            FullName = fullName;
            BusinessName = businessName;
            Email = email;
            Phone = phone;
        }
    }
}
