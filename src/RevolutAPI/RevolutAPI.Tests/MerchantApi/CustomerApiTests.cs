using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Customers;
using RevolutAPI.Models.MerchantApi.Orders;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.MerchantApi;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RevolutAPI.Tests.MerchantApi
{
    public class CustomerApiTests
    {
        private CustomersApiClient _customerApiClient;
        private OrderApiClient _orderApiClient;
        private MerchantPaymentsApiClient _merchantPaymentsApiClient;

        public CustomerApiTests()
        {
            _customerApiClient = new CustomersApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTENDPOINT));
            _orderApiClient = new OrderApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTENDPOINT));
            _merchantPaymentsApiClient = new MerchantPaymentsApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY, "https://sandbox-merchant.revolut.com/api"));
        }

        [Fact]
        public async void CustomerFlow_Success()
        {
            Random rd = new Random();
            int index = rd.Next(1, 10000);

            CreateCustomerRequest customerRequest = new CreateCustomerRequest
            {
                FullName = $"test customer{index}",
                Email = $"test.customer{index}@testing.ssrd.io"
            };

            Result<CreateCustomerResponse> createCustomer = await _customerApiClient.CreateCustomer(customerRequest);
            if (createCustomer.Failure)
            {
                Assert.False(createCustomer.Success);
            }

            string newName = $"testing customer{index}";

            UpdateCustomerRequest updateCustomerRequest = new UpdateCustomerRequest
            {
                FullName = newName
            };

            RetrieveCustomersResponse updateCustomer = await _customerApiClient.UpdateCustomer(createCustomer.Value.Id, updateCustomerRequest);

            CustomerDetailsResponse retrieveCustomer = await _customerApiClient.RetrieveCustomer(createCustomer.Value.Id);
            if(retrieveCustomer.FullName != newName)
            {
                Assert.False(retrieveCustomer.FullName != newName);
            }

            bool deleteCustomer = await _customerApiClient.DeleteCustomer(createCustomer.Value.Id);

            Assert.True(deleteCustomer);
        }

        [Fact]
        public async void RetrieveCustomer_Failure()
        {
            CustomerDetailsResponse retrievedCustomer = await _customerApiClient.RetrieveCustomer("123");

            Assert.Null(retrievedCustomer);
        }
    }
}
