using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.TeamMembers
{
    public class InviteMemberReq
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("role_id")]
        public string RoleId { get; set; }
        public InviteMemberReq(string email, string roleId)
        {
            Email = email;
            RoleId = roleId;
        }
    }
}
