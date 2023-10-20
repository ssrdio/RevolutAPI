using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class ConfirmOrderResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("payment_method")]
        public ConfirmPaymentMethodResp PaymentMethod {  get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("authentication_challenge")]
        public AuthenticationChallengeResp AuthenticationChallenge { get; set; }
    }

    public class ConfirmPaymentMethodResp
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("subtype")]
        public string SubType { get; set; }
    }

    public class AuthenticationChallengeResp
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("acs_url")]
        public string AcsUrl { get; set; }
    }
}
