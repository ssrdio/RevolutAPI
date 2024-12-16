using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.Transactions.Objects;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Transactions
{
    public class GetTransactionsResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("reason_code")]
        public string ReasonCode {  get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("scheduled_for")]
        public DateTime ScheduledFor { get; set; }
        [JsonProperty("related_transaction_id")]
        public string RelatedTransactionId { get; set; }
        [JsonProperty("merchant")]
        public Merchant Merchant { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("legs")]
        public List<TransactionLeg> Legs { get; set; }
        [JsonProperty("card")]
        public TransactionCard Card { get; set; }


    }

    
}
