using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Card
{
    public class GetCardsReq
    {
        [JsonProperty("created_before", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedBefore { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        public GetCardsReq(DateTime? createdBefore = null,int? limit = null)
        {
            CreatedBefore = createdBefore;
            Limit = limit;
        }
    }
}
