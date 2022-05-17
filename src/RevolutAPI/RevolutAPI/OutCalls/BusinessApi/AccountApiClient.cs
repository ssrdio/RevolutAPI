using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RevolutAPI.Models.BusinessApi.Account;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class AccountApiClient
    {
        private readonly IRevolutApiClient _apiClient;

        public AccountApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }

        public async Task<List<GetAccountResp>> GetAccounts()
        {
            string endpoint = "/accounts";
            return await _apiClient.Get<List<GetAccountResp>>(endpoint);
        }

        public async Task<GetAccountResp> GetAccount(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException();
            }

            string endpoint = "/accounts/" + id;
            return await _apiClient.Get<GetAccountResp>(endpoint);
        }

        public async Task<List<GetAccountDetailsResp>> GetAccountDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException();
            }

            string endpoint = "/accounts/" + id + "/bank-details";
            return await _apiClient.Get<List<GetAccountDetailsResp>>(endpoint);
        }
    }
}