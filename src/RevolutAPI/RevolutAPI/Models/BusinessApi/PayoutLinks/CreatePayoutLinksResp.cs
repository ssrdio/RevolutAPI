using Newtonsoft.Json;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PayoutLinks
{
    public class CreatePayoutLinksResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("counterparty_name")]
        public string CounterpartyName { get; set; }
        [JsonProperty("save_counterparty")]
        public bool SaveCounterparty { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("expiry_date")]
        public DateTime ExpiryDate { get; set; }
        [JsonProperty("payout_methods")]
        public List<PayoutMethods> PayoutMethods { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("transfer_reason_code")]
        public string TransferReasonCode { get; set; }
    }
}
