using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.ForeignExchange
{
    public class ExchangeMoneyResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("reason_code")]
        public string ReasonCode {  get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt {  get; set; }
        [JsonProperty("completed_at")]
        public DateTime CompletedAt { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
