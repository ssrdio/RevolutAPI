using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.Card;
using RevolutAPI.Models.BusinessApi.Counterparties.Objects;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RevolutAPI.Models.BusinessApi.Counterparties
{
    public class GetCounterpartyResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("revtag")]
        public string Revtag { get; set; }
        [JsonProperty("profile_type")]
        public string ProfileType { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("accounts")]
        public List<CounterpartyAccount> Accounts { get; set; }
        [JsonProperty("cards")]
        public List<CounterpartyCard> Cards { get; set; }
    }
}
