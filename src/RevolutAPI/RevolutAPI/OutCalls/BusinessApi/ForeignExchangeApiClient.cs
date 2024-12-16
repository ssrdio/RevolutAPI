using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.Account;
using RevolutAPI.Models.BusinessApi.ForeignExchange;
using RevolutAPI.Models.BusinessApi.PayoutLinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class ForeignExchangeApiClient
    {
        private readonly IRevolutApiClient _apiClient;

        public ForeignExchangeApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }

        public async Task<GetExchangeRateResp> GetExchangeRate(GetExchangeRateReq request)
        {
            string endpoint = "/1.0/rate";

            var queryString = BuildQueryString(request);


            if (!string.IsNullOrEmpty(queryString))
            {
                endpoint += "?" + queryString;
            }
            return await _apiClient.Get<GetExchangeRateResp>(endpoint);

           
        }
        public async Task<Result<ExchangeMoneyResp>> Exchange(ExchangeMoneyReq request)
        {
            string endpoint = "/1.0/exchange";
            return await _apiClient.Post<ExchangeMoneyResp>(endpoint, request);
        }
        private string BuildQueryString(GetExchangeRateReq request)
        {
            var parameters = new List<string>();


            if (request.From != null)
            {
                parameters.Add($"from={request.From}");
            }


            if (request.Amount != null)
            {
                parameters.Add($"amount={request.Amount}");

            }


            if (request.To != null)
            {
                parameters.Add($"to={request.To}");
            }


            return string.Join("&", parameters);
        }
    }
}
