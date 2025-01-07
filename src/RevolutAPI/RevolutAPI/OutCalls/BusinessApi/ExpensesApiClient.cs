using RevolutAPI.Models.BusinessApi.Card;
using RevolutAPI.Models.BusinessApi.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class ExpensesApiClient
    {
        private readonly IRevolutApiClient _apiClient;

        public ExpensesApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }

        public async Task<List<GetExpenseResp>> GetExpenses(GetExpensesReq request)
        {
            string endpoint = "/1.0/expenses";

            var queryString = BuildQueryString(request);


            if (!string.IsNullOrEmpty(queryString))
            {
                endpoint += "?" + queryString;
            }
            return await _apiClient.Get<List<GetExpenseResp>>(endpoint);
        }
        public async Task<GetExpenseResp> GetExpense(string expenseId)
        {
            string endpoint = $"/1.0/expenses/{expenseId}";

            return await _apiClient.Get<GetExpenseResp>(endpoint);
        }

        private string BuildQueryString(GetExpensesReq request)
        {
            var parameters = new List<string>();

            if (request.From.HasValue)
            {
                string fromDate = request.From.Value.ToString("yyyy-MM-dd");
                parameters.Add($"from={fromDate}");

            }

            if (request.To.HasValue)
            {
                string toDate = request.To.Value.ToString("yyyy-MM-dd");
                parameters.Add($"to={toDate}");

            }

            if (request.Count.HasValue)
            {
                parameters.Add($"count={request.Count.Value}");
            }

            if (request.State != null)
            {
                parameters.Add($"state={request.State}");
            }
            if (request.TransactionType != null)
            {
                parameters.Add($"transaction_type={request.TransactionType}");
            }

            return string.Join("&", parameters);
        }
    }
}
