using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Locations.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Locations
{
    public class CreateLocationResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("details")]
        public LocationDetails Details { get; set; }
    }
}
