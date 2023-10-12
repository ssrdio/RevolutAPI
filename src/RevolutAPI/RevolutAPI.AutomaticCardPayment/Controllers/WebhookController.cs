using Microsoft.AspNetCore.Mvc;
using RevolutAPI.AutomaticCardPayment.Features.Webhooks;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Webhook;

namespace RevolutAPI.AutomaticCardPayment.Controllers
{
    public class WebhookController : BaseController
    {
        private readonly WebhookService _webhookService;

        public WebhookController(WebhookService webhookService)
        {
            _webhookService = webhookService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWebhook([FromBody] CreateWebhookReq request)
        {
            Result<CreateWebhookResp> result = await _webhookService.CreateWebhook(request);
            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<IActionResult> GetWebhooks()
        {
            List<WebhooksResp> result = await _webhookService.GetWebhooks();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetWebhook([FromQuery] string webhookId)
        {
            WebhookDetailsResp result = await _webhookService.GetWebhook(webhookId);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWebhook([FromQuery] string webhookId)
        {
            bool isDeleted = await _webhookService.DeleteWebhook(webhookId);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
