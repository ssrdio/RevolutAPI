using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.MerchantApi
{
    public class MerchantPaymentsApiClient
    {
        private readonly RevolutSimpleClient _apiClient;

        public MerchantPaymentsApiClient(RevolutSimpleClient apiClient)
        {
            _apiClient = apiClient;
        }

        /// <summary>
        /// Use this endpoint to charge from saved payment methods
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="confirmOrderReq"></param>
        /// <returns></returns>
        public async Task<Result<ConfirmOrderResp>> ConfirmOrder(string orderId, ConfirmOrderReq confirmOrderReq)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/orders/{orderId}/payments";
            Result<ConfirmOrderResp> result = await _apiClient.Post<ConfirmOrderResp>(endpoint, confirmOrderReq);
            return result;
        }

        public async Task<List<PaymentDetailsResponse>> RetrievePayments(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/orders/{orderId}/payments";
            List<PaymentDetailsResponse> result = await _apiClient.Get<List<PaymentDetailsResponse>>(endpoint);
            return result;
        }

        public async Task<PaymentDetailsResponse> RetrievePaymentDetails(string paymentId)
        {
            if (string.IsNullOrEmpty(paymentId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/payments/{paymentId}";
            PaymentDetailsResponse result = await _apiClient.Get<PaymentDetailsResponse>(endpoint);
            return result;
        }

        public async Task<List<OrdersPaymentResp>> RetrievePaymentListOfOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/orders/{orderId}/payments";
            List<OrdersPaymentResp> result = await _apiClient.Get<List<OrdersPaymentResp>>(endpoint);
            return result;
        }
    }
}
