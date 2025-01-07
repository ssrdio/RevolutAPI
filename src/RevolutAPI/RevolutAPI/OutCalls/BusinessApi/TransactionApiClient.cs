using RevolutAPI.Models.BusinessApi.PayoutLinks;
using RevolutAPI.Models.BusinessApi.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class TransactionApiClient
    {
        private readonly IRevolutApiClient _revolutApiClient;

        public TransactionApiClient(IRevolutApiClient client)
        {
            _revolutApiClient = client;
        }

        public async Task<List<GetTransactionsResp>> GetTransactions(GetTransactionsReq request)
        {
            string endpoint = "/1.0/transactions";
            var queryString = BuildQueryString(request);


            if (!string.IsNullOrEmpty(queryString))
            {
                endpoint += "?" + queryString;
            }
            return await _revolutApiClient.Get<List<GetTransactionsResp>>(endpoint);
        }
        public async Task<GetTransactionsResp> GetTransaction(string transactionId)
        {
            string endpoint = $"/1.0/transaction/{transactionId}";
            return await _revolutApiClient.Get<GetTransactionsResp>(endpoint);
        }

        private string BuildQueryString(GetTransactionsReq request)
        {
            var parameters = new List<string>();
            if (request.From.HasValue)
            {
                string fromDate= request.From.Value.ToString("yyyy-MM-dd");
                parameters.Add($"from={fromDate}");
            }
            if (request.To.HasValue)
            {
                string toDate = request.To.Value.ToString("yyyy-MM-dd");
                parameters.Add($"to={toDate}");
            }
            if(request.Account != null)
            {
                parameters.Add($"account={request.Account}");
            }
            if (request.Count.HasValue)
            {
                parameters.Add($"count={request.Count}");
            }
            if(request.Type != null)
            {
                parameters.Add($"type={request.Type}");
            }

            return string.Join("&", parameters);
        }
    }
}
