using Newtonsoft.Json;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class OrderPayment
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("decline_reason")]
        public string DeclineReason { get; set; }
        [JsonProperty("bank_message")]
        public string BankMessage { get; set; }
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("amount")]
        public int Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("settled_amount")]
        public int SettledAmount { get; set; }
        [JsonProperty("settled_currency")]
        public string SettledCurrency { get; set; }
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

