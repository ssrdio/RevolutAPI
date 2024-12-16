using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.WebHookV2.WebHookEvents;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PayoutLinks
{
    public class GetPayoutLinksReq
    {
        [JsonProperty("state",NullValueHandling = NullValueHandling.Ignore)]
        public List<PayoutLinkState>? State {  get; set; }
        [JsonProperty("created_before", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedBefore { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        public GetPayoutLinksReq(List<PayoutLinkState>? state = null,DateTime? createdBefore = null,int? limit = null)
        {
            State = state;
            CreatedBefore = createdBefore;
            Limit = limit;
        }
    }


}
