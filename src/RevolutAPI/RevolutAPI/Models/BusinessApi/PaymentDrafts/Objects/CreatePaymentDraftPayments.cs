using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PaymentDrafts.Objects
{
    public class CreatePaymentDraftPayments
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }

        public CreatePaymentDraftPayments(string accountId, Receiver receiver, double amount, string currency, string reference)
        {
            AccountId = accountId;
            Receiver = receiver;
            Amount = amount;
            Currency = currency;
            Reference = reference;
        }
    }
}
