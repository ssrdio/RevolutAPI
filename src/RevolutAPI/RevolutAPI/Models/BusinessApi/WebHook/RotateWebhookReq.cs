using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2
{
    public class RotateWebhookReq
    {
        [JsonProperty("expiration_period",NullValueHandling = NullValueHandling.Ignore)]
        public string ExpirationPeriod { get; set; }
        public RotateWebhookReq(string expiration = null)
        {
            ExpirationPeriod = expiration;
        }
    }
}
