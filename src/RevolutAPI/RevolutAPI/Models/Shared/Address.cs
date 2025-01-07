using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.Shared
{
    public class Address
    {
        [JsonProperty("street_line_1")]
        public string StreetLine1 { get; set; }
        [JsonProperty("street_line_2")]
        public string StreetLine2 { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        public Address(string streetLine1, string city, string countryCode,string postCode,string streetLine2 = null,string region = null)
        {
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            City = city;
            CountryCode = countryCode;
            Postcode = postCode;
            Region = region;
        }

    }
}
