using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevolutAPI.AutomaticCardPayment.Features.AutomaticPayment;
using RevolutAPI.AutomaticCardPayment.Features.AutomaticPayment.Models;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Payments;

namespace RevolutAPI.AutomaticCardPayment.Controllers
{
    public class AutomaticPaymentController : BaseController
    {
        private readonly AutomaticPaymentService _automaticPaymentService;

        public AutomaticPaymentController(AutomaticPaymentService automaticPaymentService)
        {
            _automaticPaymentService = automaticPaymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAndOrder([FromBody] CreateCustomerAndOrder request)
        {
            Result<string> result = await _automaticPaymentService.CreateNewCustomerAndAutomaticPayment(request);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAndPay([FromQuery] string customerId, [FromQuery] double amount, [FromQuery] string? paymentMethodId)
        {
            Result<PayForAnOrderResp> result = await _automaticPaymentService.CreateOrderAndPay(customerId, amount, paymentMethodId);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrderForAutomaticPayment([FromQuery] string customerId, [FromQuery] double amount)
        {
            Result<string> result = await _automaticPaymentService.CreateOrderForAutomaticPayment(customerId, amount);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrderToAddCustomer([FromQuery] double amount)
        {
            Result<string> result = await _automaticPaymentService.CreateOrderForAutomaticPayment(amount);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok(result.Value);
        }
    }
}
