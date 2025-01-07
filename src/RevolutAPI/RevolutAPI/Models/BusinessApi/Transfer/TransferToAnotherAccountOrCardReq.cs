using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Transfer
{
    public class TransferToAnotherAccountOrCardReq
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }
        [JsonProperty("reference", NullValueHandling = NullValueHandling.Ignore)]
        public string Reference { get; set; }
        [JsonProperty("charge_bearer", NullValueHandling = NullValueHandling.Ignore)]
        public string ChargeBearer { get; set; }
        [JsonProperty("transfer_reason_code", NullValueHandling = NullValueHandling.Ignore)]
        public string TransferReasonCode { get; set; }

        public TransferToAnotherAccountOrCardReq(string requestId,
            string accountId, 
            Receiver receiver, 
            double amount, 
            string currency = null, 
            string reference = null, 
            string chargeBearer = null, 
            string transferReasonCode = null)
        {
            RequestId = requestId;
            AccountId = accountId;
            Receiver = receiver;
            Amount = amount;
            Currency = currency;
            Reference = reference;
            ChargeBearer = chargeBearer;
            TransferReasonCode = transferReasonCode;
        }
    }
}
