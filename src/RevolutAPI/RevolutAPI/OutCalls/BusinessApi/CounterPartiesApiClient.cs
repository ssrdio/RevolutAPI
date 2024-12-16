using System.Collections.Generic;
using System.Threading.Tasks;
using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.Counterparties;
using RevolutAPI.Models.BusinessApi.ForeignExchange;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class CounterPartiesApiClient
    {
        private readonly IRevolutApiClient _apiClient;

        public CounterPartiesApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }

        public async Task<List<GetCounterpartyResp>> GetCounterparties(GetCounterpartiesReq request)
        {
            string endpoint = "/1.0/counterparties";
            var queryString = BuildQueryString(request);


            if (!string.IsNullOrEmpty(queryString))
            {
                endpoint += "?" + queryString;
            }
            return await _apiClient.Get<List<GetCounterpartyResp>>(endpoint);
        }

        public async Task<GetCounterpartyResp> GetCounterparty(string id)
        {
            string endpoint = $"/1.0/counterparty/{id}";
            return await _apiClient.Get<GetCounterpartyResp>(endpoint);
        }

        public async Task<Result<CreateCounterpartyResp>> CreateCounterparty(CreateCounterpartyReq req)
        {
            string endpoint = "/1.0/counterparty";
            Result<CreateCounterpartyResp> result = await _apiClient.Post<CreateCounterpartyResp>(endpoint, req);
            return result;
        }

      

        public async Task<bool> DeleteCounterparty(string id)
        {
            string endpoit = "/1.0/counterparty/" + id;
            return await _apiClient.Delete(endpoit);
        }

        private string BuildQueryString(GetCounterpartiesReq request)
        {
            var parameters = new List<string>();
            
            if(request.Name != null)
            {
                parameters.Add($"name={request.Name}");
            }
            if (request.AccountNo != null)
            {
                parameters.Add($"account_no={request.AccountNo}");
            }
            if (request.SortCode != null)
            {
                parameters.Add($"sort_code={request.SortCode}");
            }
            if (request.Iban != null)
            {
                parameters.Add($"iban={request.Iban}");
            }
            if (request.Bic != null)
            {
                parameters.Add($"bic={request.Bic}");
            }
            if (request.Limit != null)
            {
                parameters.Add($"limit={request.Limit}");
            }
            if (request.CreatedBefore != null)
            {
                string createdBeforeDate = request.CreatedBefore.Value.ToString("yyyy-MM-dd");
                parameters.Add($"created_before={createdBeforeDate}");
            }

            return string.Join("&", parameters);
        }

    }
}
