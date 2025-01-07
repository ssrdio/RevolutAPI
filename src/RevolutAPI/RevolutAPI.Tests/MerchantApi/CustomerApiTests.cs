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
        private static readonly string CUSTOMER_ID = "";


        public CustomerApiTests()
        {
            _customerApiClient = new CustomersApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTAPIVERSION, Config.MERCHANTENDPOINT));
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

        [Fact]
        public async void RetrieveCustomerList()
        {
            List<RetrieveCustomersResponse> customers = await _customerApiClient.RetrieveCustomers();
            Assert.NotNull(customers);
        }

        [Fact]
        public async void RetrieveCustomerPaymentMethods()
        {
            List<PaymentMethodsResponse> customerPaymentMethods = await _customerApiClient.GetPaymentMethods(CUSTOMER_ID);
            Assert.NotNull(customerPaymentMethods);
        }
    }
}
