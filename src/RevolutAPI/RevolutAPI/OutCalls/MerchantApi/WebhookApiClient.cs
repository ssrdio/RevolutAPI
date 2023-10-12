using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Webhook;

namespace RevolutAPI.OutCalls.MerchantApi
{
    public class WebhookApiClient
    {
        private readonly RevolutSimpleClient _apiClient;

        public WebhookApiClient(RevolutSimpleClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Result<CreateWebhookResp>> CreateWebhook(CreateWebhookReq request)
        {
            string endpoint = "/webhooks";
            Result<CreateWebhookResp> result = await _apiClient.Post<CreateWebhookResp>(endpoint, request);
            return result;
        }

        public async Task<List<WebhooksResp>> GetWebhooks()
        {
            string endpoint = "/webhooks";
            List<WebhooksResp> result = await _apiClient.Get<List<WebhooksResp>>(endpoint);
            return result;
        }

        public async Task<WebhookDetailsResp> GetWebhook(string webhookId)
        {
            if (string.IsNullOrEmpty(webhookId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/webhooks/{webhookId}";
            WebhookDetailsResp result = await _apiClient.Get<WebhookDetailsResp>(endpoint);
            return result;
        }

        public async Task<WebhooksResp> UpdateWebhook(string webhookId, UpdateWebhookReq request)
        {
            if (string.IsNullOrEmpty(webhookId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/webhooks/{webhookId}";
            WebhooksResp result = await _apiClient.Put<WebhooksResp>(endpoint, request);
            return result;
        }

        public async Task<bool> DeleteWebhook(string webhookId)
        {
            if (string.IsNullOrEmpty(webhookId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/webhooks/{webhookId}";
            bool result = await _apiClient.Delete(endpoint);
            return result;
        }

        public async Task<Result<WebhookDetailsResp>> RotateWebhookSigningSecret(
            string webhookId, RotateWebhookSigningSecretReq request)
        {
            if (string.IsNullOrEmpty(webhookId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/webhooks/{webhookId}/rotate-signing-secret";
            Result<WebhookDetailsResp> result = await _apiClient.Post<WebhookDetailsResp>(endpoint, request);
            return result;
        }
    }
}
