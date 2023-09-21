using System.Collections.Generic;
using System.Threading.Tasks;
using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.Counterparties;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class CounterPartiesApiClient
    {
        private readonly IRevolutApiClient _apiClient;

        public CounterPartiesApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }

        public async Task<List<GetCounterpartyResp>> GetCounterparties()
        {
            string endpoint = "/counterparties";
            return await _apiClient.Get<List<GetCounterpartyResp>>(endpoint);
        }

        public async Task<GetCounterpartyResp> GetCounterparty(string id)
        {
            string endpoint = "/counterparty/" + id;
            return await _apiClient.Get<GetCounterpartyResp>(endpoint);
        }

        public async Task<Result<AddCounterpartyResp>> CreateCounterparty(AddCounterpartyReq req)
        {
            string endpoint = "/counterparty";
            Result<AddCounterpartyResp> result = await _apiClient.Post<AddCounterpartyResp>(endpoint, req);
            return result;
        }

        public async Task<Result<AddNonRevolutCounterpartyResp>> CreateNonRevolutCounterparty(AddNonRevolutCounterpartyReq req)
        {
            string endpoint = "/counterparty";
            return await _apiClient.Post<AddNonRevolutCounterpartyResp>(endpoint, req);
        }

        public async Task<bool> DeleteCounterparty(string id)
        {
            string endpoit = "/counterparty/" + id;
            return await _apiClient.Delete(endpoit);
        }

    }
}
