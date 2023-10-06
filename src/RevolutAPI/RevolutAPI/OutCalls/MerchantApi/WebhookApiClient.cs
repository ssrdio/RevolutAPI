using Microsoft.Extensions.Options;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Webhook;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
    }
}
