using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.TeamMembers
{
    public class GetTeamMembersReq
    {
        [JsonProperty("created_before", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedBefore { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        public GetTeamMembersReq(DateTime? createdBefore = null, int? limit = null)
        {
            CreatedBefore = createdBefore;
            Limit = limit;
        }
    }
}
