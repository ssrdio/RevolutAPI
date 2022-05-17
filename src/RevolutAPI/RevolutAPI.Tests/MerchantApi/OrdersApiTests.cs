using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Orders;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.MerchantApi;
using RichardSzalay.MockHttp;
using Xunit;

namespace RevolutAPI.Tests
{
    public class OrdersApiTests
    {
        private  MerchantApiClient _merchantApiClient;
        private  MockHttpMessageHandler _mockHttp;
        private IMemoryCache _memoryCache;
        public OrdersApiTests()
        {
            _merchantApiClient = new MerchantApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTENDPOINT));
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
        public async void TestRetriveOrder_Success()
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
    }
}
