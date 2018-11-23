using RevolutAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RevolutAPI.Models.Counterparties;

namespace RevolutAPI.OutCalls
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

        public async Task<AddCounterpartyResp> CreateCounterparty(AddCounterpartyReq req)
        {
            string endpoint = "/counterparty";
            return await _apiClient.Post<AddCounterpartyResp>(endpoint, req);
        }

        public async Task<AddNonRevolutCounterpartyResp> CreateNonRevolutCounterparty(AddNonRevolutCounterpartyReq req)
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
