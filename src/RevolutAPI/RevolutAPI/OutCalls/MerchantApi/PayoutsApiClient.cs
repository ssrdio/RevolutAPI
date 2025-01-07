using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Orders;
using RevolutAPI.Models.MerchantApi.Payouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.MerchantApi
{
    public class PayoutsApiClient
    {
        private readonly RevolutSimpleClient _apiClient;

        public PayoutsApiClient(RevolutSimpleClient client)
        {
            _apiClient = client;
        }

        public async Task<List<GetPayoutsResp>> GetPayouts(GetPayoutReq req)
        {
            string endpoint = "/api/payouts";
            var queryString = BuildQueryString(req);

            if (!string.IsNullOrEmpty(queryString))
            {
                endpoint += "?" + queryString;
            }
            List<GetPayoutsResp> result = await _apiClient.Get<List<GetPayoutsResp>>(endpoint);
            return result;
        }
        public async Task<GetPayoutsResp> GetPayout(string payout_id)
        {
            string endpoint = $"/api/payouts/{payout_id}";
            GetPayoutsResp result = await _apiClient.Get<GetPayoutsResp>(endpoint);
            return result;
        }

        private string BuildQueryString(GetPayoutReq request)
        {
            var parameters = new List<string>();
            
            if (request.Limit.HasValue)
            {
                parameters.Add($"limit={request.Limit}");
            }
            if (request.FromCreatedDate.HasValue)
            {
                string fromCreatedDate = request.FromCreatedDate.Value.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
                parameters.Add($"from_created_date={fromCreatedDate}");
            }
            if (request.ToCreatedDate.HasValue)
            {
                string toCreatedDate = request.ToCreatedDate.Value.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
                parameters.Add($"to_created_date={toCreatedDate}");
            }
            if (request.State != null)
            {
                foreach (var state in request.State)
                {
                    parameters.Add($"state={state}");
                }
            }
            if (request.Currency != null)
            {
                parameters.Add($"currency={request.Currency}");
            }

            return string.Join("&", parameters);
        }
    }
}
