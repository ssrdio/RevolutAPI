using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Orders.Objects;
using RevolutAPI.Models.MerchantApi.Payments.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Payments
{
    public class GetPaymentDetailsResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("state")]
        public string State   { get; set; }
        [JsonProperty("decline_reason")]
        public string DeclineReason { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
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
        [JsonProperty("authentication_challenge")]
        public AuthenticationChallenge AuthenticationChallenge { get; set; }
        [JsonProperty("risk_level")]
        public string RiskLevel { get; set; }
        [JsonProperty("fees")]
        public List<PaymentDetailsFee> Fees { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }
}
