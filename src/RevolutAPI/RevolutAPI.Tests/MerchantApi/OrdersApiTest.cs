using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.OutCalls.MerchantApi;
using RevolutAPI.OutCalls;
using RichardSzalay.MockHttp;
using RevolutAPI.Helpers;

using Xunit;
using RevolutAPI.Models.Shared;
using System.Collections.Generic;
using System;
using RevolutAPI.Models.Shared.Enums;
using Castle.Core.Resource;
using RevolutAPI.Models.MerchantApi.Orders;
using RevolutAPI.Models.MerchantApi.Orders.Objects;

namespace RevolutAPI.Tests.MerchantApi
{
    public class OrdersApiTest
    {
        private OrderApiClient _orderApiClient;
        private static readonly string ORDER_ID = "";
      
        public OrdersApiTest()
        {
            _orderApiClient = new OrderApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY,Config.MERCHANTAPIVERSION,Config.MERCHANTENDPOINT));
        }

        [Fact]
        public async void Test_CreateOrder_AllParameters()
        {
            Customer customer = new Customer(email:"test123@gmail.com",fullname:"Test123");

            LineItem lineItem = new LineItem(name:"TestItem1",type: "service",quantity:new Quantity(1),100,120);
            LineItem lineItem2 = new LineItem(name: "TestItem12", type: "service", quantity: new Quantity(1), 200, 220);
            List<LineItem> lineItems = new List<LineItem> { lineItem,lineItem2};
            Contact contat = new Contact(email:"test@gmail.com");

            DateTime estimatedDeliveryDate = DateTime.Now;
            string estimatedDeliveryDateString = estimatedDeliveryDate.ToString("yyyy-MM-ddTHH:mm:sszzz");
            Shipments shipment = new Shipments(companyName: "CompanyName", trackingNumber: "123321",esitmatedDeliveryDate: estimatedDeliveryDateString);
            List<Shipments> listShipments = new List<Shipments> { shipment};
            Shipping shipping = new Shipping(address:new Address(streetLine1:"streetline1",city:"Maribor",postCode:"2000",countryCode:"SI"),contact:contat,shipments:listShipments);

            Dictionary<string, string> metadata = new Dictionary<string, string>
            {
                { "keytest1", "valuetest1" },
                { "keytest2", "valuetest2" }
            };

            CreateOrderReq request = new CreateOrderReq(amount:10,
                currency:"GBP",
                description:"Krneki123",
                customer:customer,
                lineItems: lineItems,
                metadata: metadata,
                captureMode:"manual",
                shipping:shipping);

            Result<CreateOrderResp> order = await _orderApiClient.CreateOrder(request);
            Assert.NotNull(order);
        }

        [Fact]
        public async void Test_GetOrder()
        {
            GetOrderResp order = await _orderApiClient.GetOrder(ORDER_ID);
            Assert.NotNull(order);
        }

        [Fact]
        public async void Test_UpdateOrder()
        {
            UpdateOrderReq updateRequest = new UpdateOrderReq(amount: 20, currency: "GBP",captureMode:"manual");
            UpdateOrderResp updatedOrder = await _orderApiClient.UpdateOrder(ORDER_ID, updateRequest);
            Assert.NotNull(updatedOrder);
        }
        [Fact]
        public async void Test_CaptureOrder()
        {
            CaptureOrderReq request = new CaptureOrderReq(0.10);
            Result<CaptureOrderResp> capturedOrder = await _orderApiClient.CaptureOrder(ORDER_ID, request);
            Assert.NotNull(capturedOrder);
        }
        [Fact]
        public async void Test_GetOrderList()
        {
            List<OrderStateEnum> states = new List<OrderStateEnum> { OrderStateEnum.PENDING };
            GetOrderListReq req = new GetOrderListReq(limit:3,createdBefore:DateTime.UtcNow,state:states);
            List<GetOrderListResp> capturedOrders = await _orderApiClient.GetOrderList(req);
            Assert.NotNull(capturedOrders);
        }

        [Fact]
        public async void Test_CancelOrder()
        {
            Result<CancelOrderResp> cancelOrder = await _orderApiClient.CancelOrder(ORDER_ID);
            Assert.NotNull(cancelOrder);
        }
        [Fact]
        public async void Test_RefundOrder()
        {
            RefundOrderReq req = new RefundOrderReq(amount:0.10,description: "Refund for damaged goods");
            Result<RefundOrderResp> refundOrder = await _orderApiClient.RefundOrder(ORDER_ID, req);
            Assert.NotNull(refundOrder);
        }
    }
}
