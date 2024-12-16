using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Account.Objects
{
    public class BeneficiaryAddress
    {
        [JsonProperty("street_line1")]
        public string StreetLine1 { get; set; }
        [JsonProperty("street_line2")]
        public string StreetLine2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("postcode")]
        public string PostCode { get; set; }
    }
}
