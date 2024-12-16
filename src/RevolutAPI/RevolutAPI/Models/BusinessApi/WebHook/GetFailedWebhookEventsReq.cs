using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2
{
    public class GetFailedWebhookEventsReq
    {
        [JsonProperty("limit",NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        [JsonProperty("created_before", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedBefore { get; set; }

      
        public GetFailedWebhookEventsReq(int? limit = null, DateTime? createdBefore = null)
        {
            Limit = limit;
            CreatedBefore = createdBefore;
        }
    }
}
