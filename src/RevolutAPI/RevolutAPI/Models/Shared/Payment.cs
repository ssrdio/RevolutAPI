using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.Shared
{
    public class Payment
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("failure_reason")]
        public string FailureReason { get; set; }
        [JsonProperty("bank_message")]
        public string BankMessage { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get;set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("amount")]
        public Amount Amount { get; set; }
        [JsonProperty("settled_amount")]
        public Amount SettledAmount { get; set; }
        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }
        [JsonProperty("billing_address")]
        public Address BillingAddress { get; set; }
        [JsonProperty("risk_level")]
        public string RiskLevel { get; set; }
        [JsonProperty("fees")]
        public List<Fee> Fees { get; set; }
    }
}
