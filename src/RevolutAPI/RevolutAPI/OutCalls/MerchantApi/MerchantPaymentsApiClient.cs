using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Orders;
using RevolutAPI.Models.MerchantApi.Payments;
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
        public async Task<Result<PayForAnOrderResp>> ConfirmOrder(string orderId, PayForAnOrderReq confirmOrderReq)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/orders/{orderId}/payments";
            Result<PayForAnOrderResp> result = await _apiClient.Post<PayForAnOrderResp>(endpoint, confirmOrderReq);
            return result;
        }

        public async Task<List<GetPaymentListOfAnOrderResp>> RetrievePaymentListOfAnOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/orders/{orderId}/payments";
            List<GetPaymentListOfAnOrderResp> result = await _apiClient.Get<List<GetPaymentListOfAnOrderResp>>(endpoint);
            return result;
        }

        public async Task<GetPaymentDetailsResp> RetrievePaymentDetails(string paymentId)
        {
            string endpoint = $"/api/payments/{paymentId}";
            GetPaymentDetailsResp result = await _apiClient.Get<GetPaymentDetailsResp> (endpoint);
            return result;
        }




    }
}
