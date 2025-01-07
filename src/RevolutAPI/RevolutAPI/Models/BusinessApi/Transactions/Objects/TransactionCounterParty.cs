using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Transactions.Objects
{
    public class TransactionCounterParty
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("account_type")]
        public string AccountType { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
