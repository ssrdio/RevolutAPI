using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PayoutLinks
{
    public class CreatePayoutLinkReq
    {
        [JsonProperty("counterparty_name")]
        public string CounterPartyName { get; set; }
        [JsonProperty("save_counterparty", NullValueHandling = NullValueHandling.Ignore)]
        public bool SaveCounterParty { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("payout_methods",NullValueHandling = NullValueHandling.Ignore)]
        public List<PayoutMethods> PayoutMethods { get; set; }
        [JsonProperty("expiry_period", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiryPeriod { get; set; }
        [JsonProperty("transfer_reason_code", NullValueHandling = NullValueHandling.Ignore)]
        public string? TransferReasonCode { get; set; }

       
        public CreatePayoutLinkReq(
            string counterPartyName,
            string requestId,
            string accountId,
            double amount,
            string currency,
            string reference,
            string transferReasonCode = null,
            List<PayoutMethods> payoutMethods = null,
            string expiryPeriod = null,
            bool saveCounterParty = false)  
        {
            CounterPartyName = counterPartyName;
            RequestId = requestId;
            AccountId = accountId;
            Amount = amount;
            Currency = currency;
            Reference = reference;
            PayoutMethods = payoutMethods;
            ExpiryPeriod = expiryPeriod;
            TransferReasonCode = transferReasonCode;
            SaveCounterParty = saveCounterParty;  
        }
    }
}
