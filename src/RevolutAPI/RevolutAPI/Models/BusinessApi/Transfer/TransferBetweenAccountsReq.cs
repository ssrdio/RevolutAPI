using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Transfer
{
    public class TransferBetweenAccountsReq
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("source_account_id")]
        public string SourceAccountId { get; set; }
        [JsonProperty("target_account_id")]
        public string TargetAccountId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("reference",NullValueHandling =NullValueHandling.Ignore)]
        public string Reference { get; set; }
        public TransferBetweenAccountsReq(string id , string sourceAccountId, string targetId, double amount, string currnecy, string reference = null)
        {
            RequestId = id;
            SourceAccountId = sourceAccountId;
            TargetAccountId = targetId;
            Amount = amount;
            Currency = currnecy;
            Reference = reference;
        }
    }
}
