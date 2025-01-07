using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RevolutAPI.Models.BusinessApi.Transactions.GetTransactionsResp;

namespace RevolutAPI.Models.BusinessApi.Transactions.Objects
{
    public class TransactionLeg
    {
        [JsonProperty("leg_id")]
        public string LegId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("fee")]
        public double Fee { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("bill_amount")]
        public double BillAmount { get; set; }
        [JsonProperty("bill_currency")]
        public string BillCurrency { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("counterparty")]
        public TransactionCounterParty CounterParty { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("balance")]
        public double Balance { get; set; }
    }
}
