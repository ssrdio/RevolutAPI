using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.ForeignExchange;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Counterparties.Objects
{
    public class CounterpartyCard
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("last_digits")]
        public string LastDigits { get; set; }
        [JsonProperty("scheme")]
        public CardScheme Scheme { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("currency")]
        public string Currency {  get; set; }
    }
}
