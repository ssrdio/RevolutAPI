using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Customers
{
    public class CreateCustomerResponse
    {
        public string Id { get; set; }
        public string Full_name { get; set; }
        public string Business_name { get; set; }
        public string Phone { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get;set; }
        public string Email { get; set; }
    }
}
