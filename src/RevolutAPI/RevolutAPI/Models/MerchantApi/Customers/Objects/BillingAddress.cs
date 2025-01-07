using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Customers.Objects
{
    public class BillingAddress
    {
        [JsonProperty("street_line_1")]
        public string StreetLine1 { get; set; }
        [JsonProperty("street_line_2")]
        public string StreetLine2 { get; set; }
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
