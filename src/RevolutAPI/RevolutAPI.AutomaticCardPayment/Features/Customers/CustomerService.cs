using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.DAO;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Customers;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.MerchantApi;

namespace RevolutAPI.AutomaticCardPayment.Features.Customers
{
    public class CustomerService
    {
        private readonly CustomersDAO _customerDAO;
        private readonly CustomersPaymentMethodsDAO _customersPaymentMethodsDAO;
        private readonly CustomersApiClient _customersApiClient;

        private readonly RevolutSettings _revolutSettings;

        public CustomerService(
            CustomersDAO customerDAO,
            CustomersPaymentMethodsDAO customersPaymentMethodsDAO,
            IOptions<RevolutSettings> revolutSettings)
        {
            _revolutSettings = revolutSettings.Value;
            _customerDAO = customerDAO;
            _customersApiClient = new CustomersApiClient(new RevolutSimpleClient(_revolutSettings.MerchantKey, _revolutSettings.MerchantUrl));
            _customersPaymentMethodsDAO = customersPaymentMethodsDAO;
        }

        public async Task<List<CustomerEntity>> GetCustomers()
        {
            List<CustomerEntity> customers = await _customerDAO.GetAll();
            return customers;
        }

        public async Task<Result<List<CustomerEntity>>> GetCustomersToCreatePaymentMethod()
        {
            List<CustomerEntity> customers = await _customerDAO.GetAll();

            List<RetrieveCustomersResponse> revolutCustomers = await _customersApiClient.RetrieveCustomers();

            if (customers.Count() > revolutCustomers.Count())
            {
                return Result.Fail<List<CustomerEntity>>("There is more customers in db then in revolut");
            }

            foreach (var customer in revolutCustomers)
            {
                if (!customers.Select(x => x.Id).ToList().Contains(customer.Id))
                {
                    customers.Add(new CustomerEntity
                    {
                        Id = customer.Id,
                        FullName = customer.FullName,
                        BusinessName = customer.BusinessName,
                        Email = customer.Email,
                        Phone = customer.Phone
                    });
                }
            }

            return Result.Ok(customers);
        }

        public async Task<bool> AddCustomersToDb()
        {
            List<RetrieveCustomersResponse> customers = await _customersApiClient.RetrieveCustomers();

            List<CustomerEntity> customerEntities = new List<CustomerEntity>();
            foreach(var customer in customers)
            {
                CustomerEntity? existingCustomer = await _customerDAO.Get(customer.Id);
                if (existingCustomer != null)
                    continue;

                CustomerEntity newCustomerEntry = new CustomerEntity
                {
                    Id = customer.Id,
                    FullName = customer.FullName,
                    BusinessName = customer.BusinessName,
                    Email = customer.Email,
                    Phone = customer.Phone
                };

                customerEntities.Add(newCustomerEntry);
            }

            bool addCustomersToDb = await _customerDAO.AddRange(customerEntities);
            return addCustomersToDb;
        }

        public async Task<bool> AddCustomersToDbWithSavedPayments()
        {
            List<RetrieveCustomersResponse> customers = await _customersApiClient.RetrieveCustomers();

            List<CustomerEntity> customerEntities = new List<CustomerEntity>();
            List<CustomersPaymentMethodsEntity> methodsToSave = new List<CustomersPaymentMethodsEntity>();
            foreach (var customer in customers)
            {
                CustomerEntity? existingCustomer = await _customerDAO.Get(customer.Id);

                List<CustomersPaymentMethodsEntity> payments = await _customersPaymentMethodsDAO.Get(customer.Id);

                List<PaymentMethodsResponse> retrievedPayments = await _customersApiClient.GetPaymentMethods(customer.Id);

                List<string> paymentIds = payments.Select(x=>x.PaymentMethodId).ToList();

                if(retrievedPayments.Count != 0)
                {
                    foreach (var payment in retrievedPayments)
                    {
                        if (!paymentIds.Contains(payment.Id))
                        {
                            CustomersPaymentMethodsEntity newMethod = new CustomersPaymentMethodsEntity
                            {
                                CustomerId = customer.Id,
                                PaymentMethodId = payment.Id,
                                Type = payment.Type,
                                Last4 = payment.MethodDetails.Last4,
                                SavedFor = payment.SavedFor
                            };

                            methodsToSave.Add(newMethod);
                        }
                    }
                }

                if (existingCustomer != null)
                    continue;

                CustomerEntity newCustomerEntry = new CustomerEntity
                {
                    Id = customer.Id,
                    FullName = customer.FullName,
                    BusinessName = customer.BusinessName,
                    Email = customer.Email,
                    Phone = customer.Phone
                };

                customerEntities.Add(newCustomerEntry);
            }

            bool addCustomersToDb = await _customerDAO.AddRange(customerEntities);
            if (!addCustomersToDb)
            {
                return false;
            }

            bool savePaymentMethods = await _customersPaymentMethodsDAO.Add(methodsToSave);
            if (!savePaymentMethods)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteCustomer(string customerId)
        {
            bool deleteCustomer = await _customersApiClient.DeleteCustomer(customerId);
            if (!deleteCustomer)
            {
                return false;
            }

            bool deleteCustomerFromDb = await _customerDAO.DeleteCustomerWithCustomerId(customerId);
            if (!deleteCustomerFromDb)
            {
                return false;
            }

            return true;
        }

        public async Task<Result<List<CustomersPaymentMethodsEntity>>> GetCustomersSavedMethods(string customerId)
        {
            CustomerEntity? customer = await _customerDAO.Get(customerId);
            if (customer == null)
            {
                CustomerDetailsResponse getCustomer = await _customersApiClient.RetrieveCustomer(customerId);
                if (getCustomer == null)
                {
                    return Result.Fail<List<CustomersPaymentMethodsEntity>>("Customer with id doesn't exist");
                }

                CustomerEntity dbCustomer = new CustomerEntity
                {
                    Id = customerId,
                    FullName = getCustomer.FullName,
                    BusinessName = getCustomer.BusinessName,
                    Email = getCustomer.Email,
                    Phone = getCustomer.Phone,
                };

                bool addCustomerToDb = await _customerDAO.Add(dbCustomer);
                if (!addCustomerToDb)
                {
                    return Result.Fail<List<CustomersPaymentMethodsEntity>>("Can't add customer to db");
                }
            }

            List<CustomersPaymentMethodsEntity> savedMethods = await _customersPaymentMethodsDAO.Get(customerId);

            if (savedMethods.Count == 0)
            {
                List<PaymentMethodsResponse> getSavedMethods = await _customersApiClient.GetPaymentMethods(customerId);
                if (getSavedMethods.Count == 0)
                {
                    return Result.Ok(new List<CustomersPaymentMethodsEntity>());
                }

                foreach (var savedMethod in getSavedMethods)
                {
                    CustomersPaymentMethodsEntity newMethod = new CustomersPaymentMethodsEntity
                    {
                        CustomerId = customerId,
                        PaymentMethodId = savedMethod.Id,
                        Type = savedMethod.Type,
                        Last4 = savedMethod.MethodDetails.Last4,
                        SavedFor = savedMethod.SavedFor
                    };
                    savedMethods.Add(newMethod);
                }

                bool methodsAdded = await _customersPaymentMethodsDAO.Add(savedMethods);
                if (!methodsAdded)
                {
                    return Result.Fail<List<CustomersPaymentMethodsEntity>>("Can't add customers payment methods");
                }
            }

            return Result.Ok(savedMethods);
        }
    }
}
