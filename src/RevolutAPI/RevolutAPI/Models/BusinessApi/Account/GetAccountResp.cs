using Newtonsoft.Json;
using System;

namespace RevolutAPI.Models.BusinessApi.Account
{
    public class GetAccountResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("balance")]
        public double Balance { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("public")]
        public bool Public { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
