using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.MerchantApi
{
    public class OrderApiClient
    {
        private readonly RevolutSimpleClient _apiClient;

        public OrderApiClient(RevolutSimpleClient client)
        {
            _apiClient = client;
        }

        /// <summary>
        /// Amount is rounded to 2 decimals!
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<Result<OrderResp>> CreateOrder(CreateOrderReq req)
        {
            string endpoint = "/orders";
            Result<OrderResp> result = await _apiClient.Post<OrderResp>(endpoint, req);
            return result;
        }

        public async Task<List<OrderListResp>> RetrieveOrders()
        {
            string endpoint = "/orders";
            List<OrderListResp> result = await _apiClient.Get<List<OrderListResp>>(endpoint);
            return result;
        }

        public async Task<OrderResp> RetriveOrder(string orderId)
        {
            string endpoint = $"/orders/{orderId}";
            OrderResp result = await _apiClient.Get<OrderResp>(endpoint);
            return result;
        }

        public async Task<UpdateOrderResp> UpdateOrder(string orderId, UpdateOrderReq req)
        {
            string endpoint = $"/orders/{orderId}";
            UpdateOrderResp result = await _apiClient.Patch<UpdateOrderResp>(endpoint, req);
            return result;
        }

        public async Task<Result<OrderResp>> CaptureOrder(string orderId)
        {
            string endpoint = $"/orders/{orderId}/capture";
            Result<OrderResp> result = await _apiClient.Post<OrderResp>(endpoint, new object());
            return result;
        }

        public async Task<Result<OrderResp>> CancelOrder(string orderId)
        {
            string endpoint = $"/orders/{orderId}/cancel";
            Result<OrderResp> result = await _apiClient.Post<OrderResp>(endpoint, new object());
            return result;
        }

        public async Task<Result<OrderResp>> RefundOrder(string orderId, RefundOrdredReq refundOrdredReq)
        {
            string endpoint = $"/orders/{orderId}/refund";
            Result<OrderResp> result = await _apiClient.Post<OrderResp>(endpoint, refundOrdredReq);
            return result;
        }
    }
}
