using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class Checks
    {
        [JsonProperty("three_ds")]
        public ThreeDs ThreeDs { get; set; }

        [JsonProperty("cvv_verification")]
        public string CvvVerification { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("postcode")]
        public string PostCode { get; set; }
        [JsonProperty("cardholder")]
        public string CardHolder { get; set; }


    }
}
