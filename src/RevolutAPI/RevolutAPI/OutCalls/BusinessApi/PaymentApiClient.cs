using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.Payment;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class PaymentApiClient
    {
        private readonly IRevolutApiClient _apiClient;

        public PaymentApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }

        public async Task<Result<TransferResp>> CreateTransfer(TransferReq req)
        {
            string endpoint = "/transfer";
            return await _apiClient.Post<TransferResp>(endpoint, req);
        }

        public async Task<Result<CreatePaymentResp>> CreatePayment(CreatePaymentReq req)
        {
            string endpoint = "/pay";
            return await _apiClient.Post<CreatePaymentResp>(endpoint, req);
        }
        /// <summary>
        /// SchedulePayment can only accept dates whitout times
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Result<CreatePaymentResp>> SchedulePayment(SchedulePaymentReq req)
        {
            string endpoint = "/pay";
            return await _apiClient.Post<CreatePaymentResp>(endpoint, req);
        }

        public async Task<CheckPaymentStatusResp> CheckPaymentStatusByTransactionId(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                throw new ArgumentException();
            }

            string endpoint = "/transaction/" + transactionId;
            return await _apiClient.Get<CheckPaymentStatusResp>(endpoint);
        }

        public async Task<CheckPaymentStatusResp> CheckPaymentStatusByRequestId(string requestId)
        {
            if (string.IsNullOrEmpty(requestId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/transaction/{requestId}?id_type=request_id";
            return await _apiClient.Get<CheckPaymentStatusResp>(endpoint);
        }

        public async Task<List<TransactionResp>> GetTransactions(DateTime? from, DateTime? to, string type = null, string counterparty = null)
        {
            string parameters = "";
            string endpoint = string.Format("/transactions?");
            bool addAsAnd = false;
            if (from.HasValue)
            {
                string fromDate = from.Value.ToString("yyyy-MM-dd");
                endpoint += $"from={fromDate}";
                addAsAnd = true;
            }
            

            if (!string.IsNullOrEmpty(type))
            {
                if (addAsAnd)
                {
                    endpoint += "&type=" + type;
                }
                else 
                {
                    endpoint += "type=" + type;
                    addAsAnd = true;
                }
            }

            if (to.HasValue)
            {
                string toDate = to.Value.ToString("yyyy-MM-dd");
                if(addAsAnd)
                {
                    endpoint += "&to=" + toDate;
                }
                else
                {
                    endpoint += $"to={toDate}";
                    addAsAnd = true;
                }
                
            }

            if (!string.IsNullOrEmpty(counterparty))
            {
                if (addAsAnd)
                {
                    endpoint += "&counterparty=" + counterparty;
                }
                else
                {
                    endpoint += "counterparty=" + counterparty;
                    addAsAnd = true;
                }
            }

            return await _apiClient.Get<List<TransactionResp>>(endpoint);
        }

        public async Task<List<TransactionResp>> GetTransactions(string from = null, string to = null, string counterparty = null, int count = 0, string type = null)
        {
            string endpoint = $"/transactions?";

            if (!string.IsNullOrEmpty(from))
            {
                endpoint += $"from={from}&";
            }

            if (!string.IsNullOrEmpty(to))
            {
                endpoint += $"to={to}&";
            }

            if (!string.IsNullOrEmpty(counterparty))
            {
                endpoint += $"counterparty={counterparty}&";
            }

            if (count > 0)
            {
                endpoint += $"count={count}";
            }

            if (!string.IsNullOrEmpty(type))
            {
                endpoint += $"type={type}&";
            }

            if (endpoint[endpoint.Length - 1] == '?' || endpoint[endpoint.Length - 1] == '&')
            {
                endpoint = endpoint.Remove(endpoint.Length - 1);
            }


            return await _apiClient.Get<List<TransactionResp>>(endpoint);
        }

        public async Task<bool> CancelPayment(string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/transaction/{transactionId}";
            return await _apiClient.Delete(endpoint);
        }
    }
}