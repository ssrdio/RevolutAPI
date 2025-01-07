using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Transfer
{
    public class TransferBetweenAccountsResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("completed_at")]
        public DateTime CompletedAt { get; set; }
    }
}
