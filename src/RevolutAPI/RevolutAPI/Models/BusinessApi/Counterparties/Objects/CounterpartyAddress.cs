using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Counterparties.Objects
{
    public class CounterpartyAddress
    {
        [JsonProperty("street_line_1")]
        public string StreetLine1 { get; set; }
        [JsonProperty("street_line_2")]
        public string StreetLine2 { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        public CounterpartyAddress(string country, string postCode, string streetLine2 = null, string region = null, string streetLine1 = null, string city = null)
        {
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            City = city;
            Country = country;
            Postcode = postCode;
            Region = region;
        }
    }
}
