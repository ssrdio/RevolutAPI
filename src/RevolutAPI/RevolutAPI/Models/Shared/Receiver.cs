using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.Shared
{
    public class Receiver
    {
        [JsonProperty("counterparty_id")]
        public string CounterpartyId { get; set; }
        [JsonProperty("account_id")]
        public string? AccountId { get; set; }
        [JsonProperty("card_id")]
        public string? CardId { get; set; }

        public Receiver(string counterpartyId,string? accountId,string? cardId)
        {
            CounterpartyId = counterpartyId;
            AccountId = accountId;
            CardId = cardId;
        }
    }
}
