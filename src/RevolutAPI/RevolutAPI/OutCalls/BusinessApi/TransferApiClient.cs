using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.Account;
using RevolutAPI.Models.BusinessApi.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class TransferApiClient
    {
        private readonly IRevolutApiClient _revolutApiClient;

        public TransferApiClient(IRevolutApiClient client)
        {
            _revolutApiClient = client;
        }

        public async Task<Result<TransferBetweenAccountsResp>> TransferMoneyBetweenAccounts(TransferBetweenAccountsReq request)
        {
            string endpoint = "/1.0/transfer";
            return await _revolutApiClient.Post<TransferBetweenAccountsResp>(endpoint,request);
        }

        public async Task<Result<TransferToAnotherAccountOrCardResp>> TransferToAnotherAccountOrCard(TransferToAnotherAccountOrCardReq request)
        {
            string endpoint = "/1.0/pay";
            return await _revolutApiClient.Post<TransferToAnotherAccountOrCardResp>(endpoint,request);
        }
     
    }
}
