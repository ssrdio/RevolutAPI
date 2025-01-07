using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class Customer
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        public Customer(string id = null, string fullname = null, string phone = null, string email = null)
        {
            Id = id;
            FullName = fullname;
            Phone = phone;
            Email = email;
        }
    }
}
