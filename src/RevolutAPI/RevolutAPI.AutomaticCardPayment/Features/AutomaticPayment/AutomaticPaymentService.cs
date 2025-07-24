using Microsoft.Extensions.Options;
using RevolutAPI.AutomaticCardPayment.Features.AutomaticPayment.Models;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.DAO;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Customers;
using RevolutAPI.Models.MerchantApi.Orders;
using RevolutAPI.Models.MerchantApi.Orders.Objects;
using RevolutAPI.Models.MerchantApi.Payments;
using RevolutAPI.Models.MerchantApi.Payments.Objects;
using RevolutAPI.Models.Shared;
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
            _customersApiClient = new CustomersApiClient(new RevolutSimpleClient(_revolutSettings.MerchantKey, "2024-09-01", _revolutSettings.MerchantUrl));
            _orderApiClient = new OrderApiClient(new RevolutSimpleClient(_revolutSettings.MerchantKey, "2024-09-01", _revolutSettings.MerchantUrl));
            _merchantPaymentsApiClient = new MerchantPaymentsApiClient(new RevolutSimpleClient(_revolutSettings.MerchantKey, "2024-09-01", _revolutSettings.MerchantNewUrl));

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

            Customer cust = new Customer(
                fullname: newCustomer.FullName, 
                id: createNewCustomer.Value.Id,
                email: newCustomer.Email, 
                phone: newCustomer.Phone);

            bool customerAdded = await _customerDAO.Add(customer);
            if(!customerAdded)
            {
                return Result.Fail<string>("Can't add customer to db");
            }


            CreateOrderReq firstOrder = new CreateOrderReq(amount: request.Amount, currency: "EUR", customer: cust, description: request.Description);
           

            Result<CreateOrderResp> createFirstOrder = await _orderApiClient.CreateOrder(firstOrder);
            if(createFirstOrder.Failure)
            {
                return Result.Fail<string>("Can't create order");
            }

            return Result.Ok(createFirstOrder.Value.Id);
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
            Customer cust = new Customer(
                fullname: dbCustomer.FullName,
                id: dbCustomer.Id,
                email: dbCustomer.Email,
                phone: dbCustomer.Phone);

            CreateOrderReq firstOrder = new CreateOrderReq(
                amount: amount,
                currency: "EUR",
                customer: cust,
                captureMode: "automatic");
           

            Result<CreateOrderResp> createFirstOrder = await _orderApiClient.CreateOrder(firstOrder);
            if (createFirstOrder.Failure)
            {
                return Result.Fail<string>("Can't create first oreder");
            }

            return Result.Ok(createFirstOrder.Value.Id);
        }

        public async Task<Result<PayForAnOrderResp>> CreateOrderAndPay(string customerId, double amount, string? paymentMethodId)
        {
            CustomerEntity? dbCustomer = await _customerDAO.Get(customerId);

            Customer cust = new Customer(
                fullname: dbCustomer.FullName,
                id: dbCustomer.Id,
                email: dbCustomer.Email,
                phone: dbCustomer.Phone);

            CreateOrderReq createOrder = new CreateOrderReq(
                amount: amount,
                currency: "EUR",
                customer: cust);
           
            List<CustomersPaymentMethodsEntity> savedMethods = await _customersPaymentMethodsDAO.Get(customerId);

            CustomersPaymentMethodsEntity? temp = (paymentMethodId == null) 
                ? savedMethods.First() 
                : savedMethods
                    .Where(x => x.PaymentMethodId == paymentMethodId)
                    .SingleOrDefault();

            if (temp == null)
            {
                return Result.Fail<PayForAnOrderResp>("Can't get saved methods");
            }

            Result<CreateOrderResp> sendOrder = await _orderApiClient.CreateOrder(createOrder);
            if (sendOrder.Failure)
            {
                return Result.Fail<PayForAnOrderResp>("Can't send order");
            }
            SavedPaymentMethod savedPaymentMethod = new SavedPaymentMethod(
                id: temp.PaymentMethodId,
                type: temp.Type.ToLower(),
                initiator: temp.SavedFor.ToLower());

            PayForAnOrderReq confirmOrder = new PayForAnOrderReq(
                savedPaymentMethod: savedPaymentMethod);

            confirmOrder.SavedPaymentMethod.Environment = new RevolutAPI.Models.MerchantApi.Payments.Objects.Enviroment
            (
                type: "browser",
                timezone: 180,
                colorDepth: 48,
                screenWidth: 1920,
                screenHeight: 1080,
                javaEnabled: true,
                challengeWindowWidth: 640,
                url: "https://business.revolut.com"
            );
            
            Result<PayForAnOrderResp> chargePayment = await _merchantPaymentsApiClient.ConfirmOrder(sendOrder.Value.Id, confirmOrder);
            if (chargePayment.Failure)
            {
                return Result.Fail<PayForAnOrderResp>("Can't confirm order");
            }

            return chargePayment;
        }


        // Second method

        public async Task<Result<string>> CreateOrderForAutomaticPayment(double amount)
        {
            CreateOrderReq firstOrder = new CreateOrderReq(amount: amount, currency: "EUR");


            Result<CreateOrderResp> createFirstOrder = await _orderApiClient.CreateOrder(firstOrder);
            if (createFirstOrder.Failure)
            {
                return Result.Fail<string>("Can't create order");
            }

            return Result.Ok(createFirstOrder.Value.Id);
        }


        public async Task<Result> Create(string name, string email, string phone)
        {
            Customer customer = new Customer(
              fullname: name,
              email: email,
              phone: phone);

            CreateOrderReq addPaymnetOrder = new CreateOrderReq(
                amount: 0.0,
                currency: "EUR",
                customer: customer,
                description: "request.Description");

            RevolutAPI.Helpers.Result<CreateOrderResp> createOrderResult = await _orderApiClient.CreateOrder(addPaymnetOrder);
            if (createOrderResult.Failure)
            {
                
                return Result.Fail(createOrderResult.Error);
            }

            return Result.Ok();
        }

        public async Task<bool> ChargeAllCustomers(double amount)
        {
            List<CustomerEntity> customers = await _customerDAO.GetAllIncluded();

            Dictionary<string, PayForAnOrderResp> customersPayment = new Dictionary<string, PayForAnOrderResp>();

            foreach (CustomerEntity customer in customers)
            {
                var paymentMethods = customer.PaymentMethods;
                if (paymentMethods.Count == 0)
                    continue;

                var paymentMethod = paymentMethods.First();
                Customer cust = new Customer(fullname: customer.FullName, id: customer.Id, email: customer.Email, phone: customer.Phone);

                CreateOrderReq createOrder = new CreateOrderReq(amount: amount, currency: "EUR",customer:cust);
               

                Result<CreateOrderResp> sendOrder = await _orderApiClient.CreateOrder(createOrder);
                if (sendOrder.Failure)
                {
                    return false;
                }
                SavedPaymentMethod savedPaymentMethod = new SavedPaymentMethod(
                    id: paymentMethod.PaymentMethodId,
                    type: paymentMethod.Type.ToLower(),
                    initiator: paymentMethod.SavedFor.ToLower());

                PayForAnOrderReq confirmOrder = new PayForAnOrderReq(
                    savedPaymentMethod:savedPaymentMethod);
                
                if (paymentMethod.Type.ToLower() != "merchant")
                {
                    confirmOrder.SavedPaymentMethod.Environment = new RevolutAPI.Models.MerchantApi.Payments.Objects.Enviroment
                    (
                        type : "browser",
                        timezone : 180,
                        colorDepth : 48,
                        screenWidth : 1920,
                        screenHeight : 1080,
                        javaEnabled : true,
                        challengeWindowWidth : 640,
                        url : "https://business.revolut.com"
                    );
                }

                Result<PayForAnOrderResp> chargePayment = await _merchantPaymentsApiClient.ConfirmOrder(sendOrder.Value.Id, confirmOrder);
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
