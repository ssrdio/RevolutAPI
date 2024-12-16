using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Payments.Objects
{
    public class Enviroment
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("time_zone_utc_offset")]
        public int TimeZoneUTCOffset { get; set; }
        [JsonProperty("color_depth")]
        public int ColorDepth { get; set; }
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
        public Enviroment(string type, int timezone , int colorDepth, int screenWidth, int screenHeight, bool javaEnabled, int challengeWindowWidth, string url = null)
        {
            Type = type; 
            TimeZoneUTCOffset = timezone; 
            ColorDepth = colorDepth; 
            ScreenWidth = screenWidth; 
            ScreenHeight = screenHeight; 
            JavaEnabled = javaEnabled; 
            ChallengeWindowWidth = challengeWindowWidth;     
            Url = url;

        }
    }
}
