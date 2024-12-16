using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PaymentDrafts.Objects
{
    public class GetPaymentDraftPayment
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("amount")]
        public PaymentDraftsAmount Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("reason")]
        public string Reason { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        [JsonProperty("current_charge_options")]
        public ChargeOptions CurrentChargeOptions { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
