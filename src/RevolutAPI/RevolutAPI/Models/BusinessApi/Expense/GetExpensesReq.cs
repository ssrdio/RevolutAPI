using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Expense
{
    public class GetExpensesReq
    {
        [JsonProperty("from")]
        public DateTime? From { get; set; }
        [JsonProperty("to")]
        public DateTime? To { get; set; }
        [JsonProperty("count")]
        public int? Count { get; set; }
        [JsonProperty("state")]
        public string? State { get; set; }
        [JsonProperty("transaction_type")]
        public string? TransactionType { get; set; }

        public GetExpensesReq(DateTime? from = null,
            DateTime? to = null, 
            int? count = null, 
            string state = null,
            string transactionType = null)
        {
            From = from;
            To = to;
            Count = count;
            State = state;
            TransactionType = transactionType;
        }
    }
}
