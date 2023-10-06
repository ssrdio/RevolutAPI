using Microsoft.Extensions.Options;
using RevolutAPI.AutomaticCardPayment.Features.AutomaticPayment.Models;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.DAO;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Customers;
using RevolutAPI.Models.MerchantApi.Orders;
using RevolutAPI.Models.Shared.Enums;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.MerchantApi;
using System.Security.Cryptography.Xml;

namespace RevolutAPI.AutomaticCardPayment.Features.AutomaticPayment
{
    public class AutomaticPaymentService
    {
        private readonly CustomersApiClient _customersApiClient;
        private readonly OrderApiClient _orderApiClient;
        private readonly MerchantPaymentsApiClient _merchantPaymentsApiClient;

        private readonly CustomersDAO _customerDAO;
        private readonly CustomersPaymentMethodsDAO _customersPaymentMethodsDAO;
        private readonly AutomaticChargeDAO _automaticChargeDAO;

        private readonly RevolutSettings _revolutSettings;

        public AutomaticPaymentService(
            CustomersDAO customersDAO,
            CustomersPaymentMethodsDAO customersPaymentMethodsDAO,
            AutomaticChargeDAO automaticChargeDAO,
            IOptions<RevolutSettings> revolutSettings)
        {
            _revolutSettings = revolutSettings.Value;
            _customersApiClient = new CustomersApiClient(new RevolutSimpleClient(_revolutSettings.MerchantKey, _revolutSettings.MerchantUrl));
            _orderApiClient = new OrderApiClient(new RevolutSimpleClient(_revolutSettings.MerchantKey, _revolutSettings.MerchantUrl));
            _merchantPaymentsApiClient = new MerchantPaymentsApiClient(new RevolutSimpleClient(_revolutSettings.MerchantKey, _revolutSettings.MerchantNewUrl));

            _customerDAO = customersDAO;
            _customersPaymentMethodsDAO = customersPaymentMethodsDAO;
            _automaticChargeDAO = automaticChargeDAO;
        }

        // First method
        public async Task<Result<string>> CreateNewCustomerAndAutomaticPayment(CreateCustomerAndOrder request)
        {
            CreateCustomerRequest newCustomer = new CreateCustomerRequest
            {
                FullName = request.FullName,
                BusinessName = request.BusinessName,
                Email = request.Email,
                Phone = request.Phone
            };

            Result<CreateCustomerResponse> createNewCustomer = await _customersApiClient.CreateCustomer(newCustomer);
            if (createNewCustomer.Failure)
            {
                return Result.Fail<string>("Can't create new customer");
            }

            CustomerEntity customer = new CustomerEntity
            {
                FullName = newCustomer.FullName,
                Id = createNewCustomer.Value.Id,
                BusinessName = newCustomer.BusinessName,
                Email = newCustomer.Email,
                Phone = newCustomer.Phone
            };

            bool customerAdded = await _customerDAO.Add(customer);
            if(!customerAdded)
            {
                return Result.Fail<string>("Can't add customer to db");
            }

            CreateOrderReq firstOrder = new CreateOrderReq
            {
                Amount = request.Amount,
                Currency = "EUR",
                CustomerId = createNewCustomer.Value.Id,
                Description = request.Description,
                MerchantCustomerExtRef = request.MerchantCustomerExtRef,
                MerchantOrderExtRef = request.MerchantOrderExtRef,
            };

            Result<OrderResp> createFirstOrder = await _orderApiClient.CreateOrder(firstOrder);
            if(createFirstOrder.Failure)
            {
                return Result.Fail<string>("Can't create order");
            }

            return Result.Ok(createFirstOrder.Value.PublicId);
        }

        public async Task<Result<string>> CreateOrderForAutomaticPayment(string customerId, double amount)
        {
            CustomerDetailsResponse? customer = await _customersApiClient.RetrieveCustomer(customerId);
            if(customer == null)
            {
                return Result.Fail<string>("Can't get customer");
            }

            CustomerEntity? dbCustomer = await _customerDAO.Get(customerId);
            if(dbCustomer == null)
            {
                CustomerEntity customerEntry = new CustomerEntity
                {
                    Id = customer.Id,
                    FullName = customer.FullName,
                    BusinessName = customer.BusinessName,
                    Email = customer.Email,
                    Phone = customer.Phone
                };

                bool entryCustomerAdded = await _customerDAO.Add(customerEntry);
                if (!entryCustomerAdded)
                {
                    return Result.Fail<string>("Can't add customer to db");
                }
            }

            CreateOrderReq firstOrder = new CreateOrderReq
            {
                CaptureMode = CaptureModeEnum.AUTOMATIC, 
                Amount = amount,
                Currency = "EUR",
                CustomerId = customerId
            };

            Result<OrderResp> createFirstOrder = await _orderApiClient.CreateOrder(firstOrder);
            if (createFirstOrder.Failure)
            {
                return Result.Fail<string>("Can't create first oreder");
            }

            return Result.Ok(createFirstOrder.Value.PublicId);
        }

        public async Task<Result<ConfirmOrderResp>> CreateOrderAndPay(string customerId, double amount, string? paymentMethodId)
        {
            CreateOrderReq createOrder = new CreateOrderReq
            {
                Amount = amount,
                Currency = "EUR",
                CustomerId = customerId,
            };

            List<CustomersPaymentMethodsEntity> savedMethods = await _customersPaymentMethodsDAO.Get(customerId);
            CustomersPaymentMethodsEntity? temp = (paymentMethodId == null) ? savedMethods.First() : savedMethods.Where(x => x.PaymentMethodId == paymentMethodId).SingleOrDefault();
            if (temp == null)
            {
                return Result.Fail<ConfirmOrderResp>("Can't get saved methods");
            }

            Result<OrderResp> sendOrder = await _orderApiClient.CreateOrder(createOrder);
            if (sendOrder.Failure)
            {
                return Result.Fail<ConfirmOrderResp>("Can't send order");
            }

            ConfirmOrderReq confirmOrder = new ConfirmOrderReq
            {
                SavedPaymentMethod = new SavedPaymentMethod
                {
                    Id = temp.PaymentMethodId,
                    Type = temp.Type.ToLower(),
                    Initiator = temp.SavedFor.ToLower()
                }
            };

            Result<ConfirmOrderResp> chargePayment = await _merchantPaymentsApiClient.ConfirmOrder(sendOrder.Value.Id, confirmOrder);
            if (chargePayment.Failure)
            {
                return Result.Fail<ConfirmOrderResp>("Can't confirm order");
            }

            return chargePayment;
        }


        // Second method

        public async Task<Result<string>> CreateOrderForAutomaticPayment(double amount)
        {
            CreateOrderReq firstOrder = new CreateOrderReq
            {
                Amount = amount,
                Currency = "EUR"
            };

            Result<OrderResp> createFirstOrder = await _orderApiClient.CreateOrder(firstOrder);
            if (createFirstOrder.Failure)
            {
                return Result.Fail<string>("Can't create order");
            }

            return Result.Ok(createFirstOrder.Value.PublicId);
        }


        public async Task<bool> ChargeAllCustomers(double amount)
        {
            List<CustomerEntity> customers = await _customerDAO.GetAllIncluded();

            Dictionary<string, ConfirmOrderResp> customersPayment = new Dictionary<string, ConfirmOrderResp>();

            foreach (CustomerEntity customer in customers)
            {
                var paymentMethods = customer.PaymentMethods;
                if (paymentMethods.Count == 0)
                    continue;

                var paymentMethod = paymentMethods.First();

                CreateOrderReq createOrder = new CreateOrderReq
                {
                    Amount = amount,
                    Currency = "EUR",
                    CustomerId = customer.Id,
                };

                Result<OrderResp> sendOrder = await _orderApiClient.CreateOrder(createOrder);
                if (sendOrder.Failure)
                {
                    return false;
                }
                
                ConfirmOrderReq confirmOrder = new ConfirmOrderReq
                {
                    SavedPaymentMethod = new SavedPaymentMethod
                    {
                        Id = paymentMethod.PaymentMethodId,
                        Type = paymentMethod.Type.ToLower(),
                        Initiator = paymentMethod.SavedFor.ToLower()
                    }
                };

                if (paymentMethod.Type.ToLower() != "merchant")
                {
                    confirmOrder.SavedPaymentMethod.Environment = new RevolutAPI.Models.MerchantApi.Orders.Environment
                    {
                        Type = "browser",
                        TimeZoneUTCOffset = 180,
                        ColorDepth = 48,
                        ScreenWidth = 1920,
                        ScreenHeight = 1080,
                        JavaEnabled = true,
                        ChallengeWindowWidth = 640,
                        Url = "https://business.revolut.com",
                    };
                }

                Result<ConfirmOrderResp> chargePayment = await _merchantPaymentsApiClient.ConfirmOrder(sendOrder.Value.Id, confirmOrder);
                if (chargePayment.Failure)
                {
                    return false;
                }

                customersPayment.Add(customer.Id, chargePayment.Value);
            }
            return true;
        }
    }
}
