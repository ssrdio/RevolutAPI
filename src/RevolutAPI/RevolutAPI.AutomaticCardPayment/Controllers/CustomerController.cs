using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevolutAPI.AutomaticCardPayment.Features.AutomaticPayment;
using RevolutAPI.AutomaticCardPayment.Features.Customers;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities;
using RevolutAPI.Helpers;

namespace RevolutAPI.AutomaticCardPayment.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            List<CustomerEntity> result = await _customerService.GetCustomers();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            Result<List<CustomerEntity>> result = await _customerService.GetCustomersToCreatePaymentMethod();
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomersFromRevolutToDb()
        {
            bool result = await _customerService.AddCustomersToDb();
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCustomersToDbWithSavedPayments()
        {
            bool result = await _customerService.AddCustomersToDbWithSavedPayments();
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string customerId)
        {
            bool result = await _customerService.DeleteCustomer(customerId);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersSavedMethods([FromQuery] string customerId)
        {
            Result<List<CustomersPaymentMethodsEntity>> result = await _customerService.GetCustomersSavedMethods(customerId);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok(result.Value);
        }
    }
}
