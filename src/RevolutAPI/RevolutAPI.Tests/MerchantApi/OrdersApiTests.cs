using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Orders;
using RevolutAPI.Models.Shared.Enums;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.MerchantApi;
using RichardSzalay.MockHttp;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RevolutAPI.Tests
{
    public class OrdersApiTests
    {
        private  OrderApiClient _merchantApiClient;
        private  MockHttpMessageHandler _mockHttp;
        private IMemoryCache _memoryCache;
        public OrdersApiTests()
        {
            _merchantApiClient = new OrderApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTENDPOINT));
        }

        [Fact]
        public async void TestCreateOrder_Success()
        {
            Result<OrderResp> order = await _merchantApiClient.CreateOrder(new CreateOrderReq
            {
                Amount = 11,
                CaptureMode = CaptureModeEnum.AUTOMATIC,
                Currency = "EUR",
                CustomerEmail = "testing@testing.ssrd.io",
                Description = "some goods for test",
                MerchantCustomerExtRef = "myCustomRef1",
                MerchantOrderExtRef = "MyOrderRef",
                SettlementCurrency = "EUR"
            });
           
            Assert.NotNull(order);
        }

        [Fact]
        public async void TestRetrieveOrder_Success()
        {
            Result<OrderResp> order = await _merchantApiClient.CreateOrder(new CreateOrderReq
            {
                Amount = 11.15d,
                CaptureMode = CaptureModeEnum.AUTOMATIC,
                Currency = "EUR",
                CustomerEmail = "testing@testing.ssrd.io",
                Description = "some goods for test",
                MerchantCustomerExtRef = "myCustomRef1",
                MerchantOrderExtRef = "MyOrderRef",
                SettlementCurrency = "EUR"
            });

            OrderResp retrived = await _merchantApiClient.RetriveOrder(order.Value.Id);

            Assert.Equal(11.15d, retrived.OrderAmount.Value);
        }

        [Fact]
        public async void TestRetrieveOrdersSuccess()
        {
            List<OrderListResp> orders = await _merchantApiClient.RetrieveOrders();

            Assert.NotNull(orders);
        }

        [Fact]
        public async void TestUpdateOrder()
        {
            var order = await _merchantApiClient.CreateOrder(new CreateOrderReq
            {
                Amount = 10,
                Currency = "EUR",
            });

            OrderResp ordersDetails = await _merchantApiClient.RetriveOrder(order.Value.Id);

            UpdateOrderResp orderUpdate = await _merchantApiClient.UpdateOrder(order.Value.Id, new UpdateOrderReq
            {
                Amount=100,
                Currency="EUR"
            });

            OrderResp newOrdersDetails = await _merchantApiClient.RetriveOrder(order.Value.Id);

            Assert.True(newOrdersDetails.OrderAmount.Value > ordersDetails.OrderAmount.Value);
        }
    }
}
