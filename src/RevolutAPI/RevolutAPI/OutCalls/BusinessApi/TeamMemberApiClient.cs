using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.PayoutLinks;
using RevolutAPI.Models.BusinessApi.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class TeamMemberApiClient
    {
        private readonly IRevolutApiClient _revolutApiClient;

        public TeamMemberApiClient(IRevolutApiClient client)
        {
            _revolutApiClient = client;
        }

        public async Task<List<GetTeamMembersResp>> GetTeamMemebers(GetTeamMembersReq request)
        {
            string endpoint = "/1.0/team-members";
            var queryString = BuildQueryString(request);


            if (!string.IsNullOrEmpty(queryString))
            {
                endpoint += "?" + queryString;
            }
         
            return await _revolutApiClient.Get<List<GetTeamMembersResp>>(endpoint);

        }
        public async Task<Result<InviteMemberResp>> InviteNewMember(InviteMemberReq request)
        {
            string endpoint = "/1.0/team-members";
            return await _revolutApiClient.Post<InviteMemberResp>(endpoint,request);

        }
      
        private string BuildQueryString(GetTeamMembersReq request)
        {
            var parameters = new List<string>();

            if (request.CreatedBefore.HasValue)
            {
                string createdBeforeDate = request.CreatedBefore.Value.ToString("yyyy-MM-dd");
                parameters.Add($"created_before={createdBeforeDate}");
            }


            if (request.Limit.HasValue)
            {
                parameters.Add($"limit={request.Limit.Value}");
            }

            return string.Join("&", parameters);
        }

    }
}
