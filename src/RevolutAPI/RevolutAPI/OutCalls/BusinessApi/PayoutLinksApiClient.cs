using RevolutAPI.Helpers;

using RevolutAPI.Models.BusinessApi.PayoutLinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class PayoutLinksApiClient
    {
        private readonly IRevolutApiClient _apiClient;

        public PayoutLinksApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }

        public async Task<List<GetPayoutLinksResp>> GetPayoutLinks(GetPayoutLinksReq request)
        {
            string endpoint = "/1.0/payout-links";

            var queryString = BuildQueryString(request);

          
            if (!string.IsNullOrEmpty(queryString))
            {
                endpoint += "?" + queryString;
            }
            return await _apiClient.Get<List<GetPayoutLinksResp>>(endpoint);
        }
        public async Task<GetPayoutLinksResp> GetPayoutLink(string id)
        {
            string endpoint = $"/1.0/payout-links/{id}";

            return await _apiClient.Get<GetPayoutLinksResp>(endpoint);
        }
        public async Task<Result<CreatePayoutLinksResp>> CreatePayoutLink(CreatePayoutLinkReq request)
        {
            string endpoint = "/1.0/payout-links";
            return await _apiClient.Post<CreatePayoutLinksResp>(endpoint, request);
        }

        public async Task<Result> CanclePayoutLink(string payoutLinkId)
        {
            string endpoint = $"/1.0/payout-links/{payoutLinkId}/cancel";
            return await _apiClient.Post<Result>(endpoint, new { }); 
        }
        public async Task<List<GetTransferReasonsResp>> GetTransferReasons()
        {
            string endpoint = "/1.0/transfer-reasons";
            return await _apiClient.Get<List<GetTransferReasonsResp>>(endpoint);
        }
        private string BuildQueryString(GetPayoutLinksReq request)
        {
            var parameters = new List<string>();

            
            if (request.State != null && request.State.Any())
            {
                parameters.AddRange(request.State.Select(state => $"state={state.ToString()}"));
            }

            
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
