using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class ConfirmOrderReq
    {
        [JsonProperty("saved_payment_method")]
        public SavedPaymentMethod SavedPaymentMethod { get; set; }   
        //[JsonProperty("enviroment")]
        //public Enviroment Enviroment { get; set; }
    }

    public class SavedPaymentMethod
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("initiator")]
        public string Initiator { get; set; }

        [JsonProperty("environment", NullValueHandling = NullValueHandling.Ignore)]
        public Environment Environment { get; set; }
    }

    public class Environment
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("time_zone_utc_offset")]
        public int TimeZoneUTCOffset { get; set; }
        [JsonProperty("color_depth")]
        public int ColorDepth {  get; set; }
        [JsonProperty("screen_width")]
        public int ScreenWidth { get; set; }
        [JsonProperty("screen_height")]
        public int ScreenHeight { get; set; }
        [JsonProperty("java_enabled")]
        public bool JavaEnabled { get; set; }
        [JsonProperty("challenge_window_width")]
        public int ChallengeWindowWidth { get; set; }
        [JsonProperty("browser_url")]
        public string Url { get; set; }
        [JsonProperty("userAgentHeader")]
        public string UserAgentHeader { get; set; }
    }
}
