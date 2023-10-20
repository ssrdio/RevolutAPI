using Microsoft.Extensions.Options;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Webhook;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.MerchantApi;

namespace RevolutAPI.AutomaticCardPayment.Features.Webhooks
{
    public class WebhookService
    {
        private readonly WebhookApiClient _webhookApiClient;

        private readonly RevolutSettings _revolutSettings;

        public WebhookService(
            IOptions<RevolutSettings> revolutSettings)
        {
            _revolutSettings = revolutSettings.Value;
            _webhookApiClient = new WebhookApiClient(
                new RevolutSimpleClient(_revolutSettings.MerchantKey, _revolutSettings.MerchantUrl));
        }

        public async Task<Result<CreateWebhookResp>> CreateWebhook(CreateWebhookReq request)
        {
            Result<CreateWebhookResp> webhook = await _webhookApiClient.CreateWebhook(request);
            return webhook;
        }

        public async Task<List<WebhooksResp>> GetWebhooks()
        {
            List<WebhooksResp> webhooks = await _webhookApiClient.GetWebhooks();
            return webhooks;
        }

        public async Task<WebhookDetailsResp> GetWebhook(string webhookId)
        {
            WebhookDetailsResp webhook = await _webhookApiClient.GetWebhook(webhookId);
            return webhook;
        }

        public async Task<bool> DeleteWebhook(string webhookId)
        {
            bool isDeleted = await _webhookApiClient.DeleteWebhook(webhookId);
            return isDeleted;
        }
    }
}
