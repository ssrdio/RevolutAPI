using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.MerchantApi
{
    public class OrderApiClient
    {
        private readonly IRevolutApiClient _apiClient;

        public OrderApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }
        public async Task<GetOrderResp> GetOrder(string orderId)
        {
            string endpoint = $"/api/orders/{orderId}";
            GetOrderResp result = await _apiClient.Get<GetOrderResp>(endpoint);
            return result;
        }
        public async Task<List<GetOrderListResp>> GetOrderList(GetOrderListReq req)
        {
            string endpoint = $"/api/1.0/orders";
            var queryString = BuildQueryString(req);

            if (!string.IsNullOrEmpty(queryString))
            {
                endpoint += "?" + queryString;
            }
            List<GetOrderListResp> result = await _apiClient.Get<List<GetOrderListResp>>(endpoint);
            return result;
        }

        public async Task<Result<CreateOrderResp>> CreateOrder(CreateOrderReq req)
        {
            string endpoint = "/api/orders";
            Result<CreateOrderResp> result = await _apiClient.Post<CreateOrderResp>(endpoint, req);
            return result;
        }
    
        public async Task<UpdateOrderResp> UpdateOrder(string orderId,UpdateOrderReq req)
        {
            string endpoint = $"/api/orders/{orderId}";
            UpdateOrderResp result = await _apiClient.Patch<UpdateOrderResp>(endpoint, req);
            return result;
        }
        public async Task<Result<CaptureOrderResp>> CaptureOrder(string orderId,CaptureOrderReq req)
        {
            string endpoint = $"/api/orders/{orderId}/capture";
            Result<CaptureOrderResp> result = await _apiClient.Post<CaptureOrderResp>(endpoint, req);
            return result;
        }
        public async Task<Result<CancelOrderResp>> CancelOrder(string orderId)
        {
            string endpoint = $"/api/orders/{orderId}/cancel";
            Result<CancelOrderResp> result = await _apiClient.Post<CancelOrderResp>(endpoint, new { });
            return result;
        }
        public async Task<Result<RefundOrderResp>> RefundOrder(string orderId,RefundOrderReq req)
        {
            string endpoint = $"/api/1.0/orders/{orderId}/refund";
            Result<RefundOrderResp> result = await _apiClient.Post<RefundOrderResp>(endpoint,req);
            return result;
        }

        private string BuildQueryString(GetOrderListReq request)
        {
            var parameters = new List<string>();
            if (request.Limit.HasValue)
            {
                parameters.Add($"limit={request.Limit}");
            }
            if (request.CustomerId != null)
            {
                parameters.Add($"customer_id={request.CustomerId}");
            }
            if (request.Email != null)
            {
                parameters.Add($"email={request.CustomerId}");
            }
            if (request.MerchantOrderExtRef != null)
            {
                parameters.Add($"merchant_order_ext_ref={request.MerchantOrderExtRef}");
            }
            if (request.State != null)
            {
                foreach (var state in request.State) {
                    parameters.Add($"state={state.ToString()}");
                }
                
            }
            if (request.CreatedBefore.HasValue)
            {
                string createdBeforeDate = request.CreatedBefore.Value.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
                parameters.Add($"created_before={createdBeforeDate}");
            }
            if (request.FromCreatedDate.HasValue)
            {
                string fromCreatedDate = request.FromCreatedDate.Value.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
                parameters.Add($"from_created_date={fromCreatedDate}");
            }
            if (request.ToCreatedDate.HasValue)
            {
                string toCreatedDate = request.ToCreatedDate.Value.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ");
                parameters.Add($"to_created_date={toCreatedDate}");
            }

            return string.Join("&", parameters);
        }
    }
}
