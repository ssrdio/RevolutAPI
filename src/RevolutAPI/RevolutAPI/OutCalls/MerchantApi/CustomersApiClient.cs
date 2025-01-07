using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Customers;
using RevolutAPI.Models.MerchantApi.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls.MerchantApi
{
    public class CustomersApiClient
    {
        private readonly RevolutSimpleClient _apiClient;

        public CustomersApiClient(RevolutSimpleClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Result<CreateCustomerResponse>> CreateCustomer(CreateCustomerRequest req)
        {
            string endpoint = "/api/1.0/customers";
            Result<CreateCustomerResponse> result = await _apiClient.Post<CreateCustomerResponse>(endpoint, req);
            return result;
        }

        public async Task<List<RetrieveCustomersResponse>> RetrieveCustomers()
        {
            string endpoint = "/api/1.0/customers";
            List<RetrieveCustomersResponse> result = await _apiClient.Get<List<RetrieveCustomersResponse>>(endpoint);
            return result;
        }
        
        public async Task<CustomerDetailsResponse> RetrieveCustomer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/1.0/customers/{id}";
            CustomerDetailsResponse result = await _apiClient.Get<CustomerDetailsResponse>(endpoint);
            return result;
        }

        public async Task<bool> DeleteCustomer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/1.0/customers/{id}";
            bool result = await _apiClient.Delete(endpoint);
            return result;
        }

        public async Task<RetrieveCustomersResponse> UpdateCustomer(string id, UpdateCustomerRequest request)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/1.0/customers/{id}";
            RetrieveCustomersResponse result = await _apiClient.Patch<RetrieveCustomersResponse>(endpoint, request);
            return result;
        }

        public async Task<List<PaymentMethodsResponse>> GetPaymentMethods(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/1.0/customers/{customerId}/payment-methods";
            List<PaymentMethodsResponse> result = await _apiClient.Get<List<PaymentMethodsResponse>>(endpoint);
            return result;
        }

        public async Task<PaymentMethodsResponse> GetPaymentMethod(string customerId, string paymentMethodId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(paymentMethodId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/1.0/customers/{customerId}/payment-methods/{paymentMethodId}";
            PaymentMethodsResponse result = await _apiClient.Get<PaymentMethodsResponse>(endpoint);
            return result;
        }

        public async Task<PaymentMethodsResponse> UpdatePaymentMethod(string customerId, string paymentMethodId, UpdatePaymentMethod request)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(paymentMethodId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/1.0/customers/{customerId}/payment-methods/{paymentMethodId}";
            PaymentMethodsResponse result = await _apiClient.Patch<PaymentMethodsResponse>(endpoint, request);
            return result;
        }

        public async Task<bool> DeletePaymentMethod(string customerId, string paymentMethodId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(paymentMethodId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/api/1.0/customers/{customerId}/payment-methods/{paymentMethodId}";
            bool result = await _apiClient.Delete(endpoint);
            return result;
        }
    }
}
