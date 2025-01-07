using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.WebHookV2;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using RevolutAPI.Models.BusinessApi.WebHookV2.WebHookEvents;

namespace RevolutAPI.OutCalls.BusinessApi
{
    public class WebhookApiClient
    {
       private readonly IRevolutApiClient _revolutApiClient;

        public WebhookApiClient(IRevolutApiClient client)
        {
            _revolutApiClient = client;
        }
        
        public async Task<List<GetWebhooksResp>> GetWebhooks()
        {
            string endpoint = "/2.0/webhooks";
            return await _revolutApiClient.Get<List<GetWebhooksResp>>(endpoint);
        }

        public async Task<GetWebhookResp> GetWebhook(string webhookId)
        {
            string endpoint = $"/2.0/webhooks/{webhookId}";
            return await _revolutApiClient.Get<GetWebhookResp>(endpoint);
        }
        public async Task<Result<CreateWebhookResp>> CreateWebhook(CreateWebhookReq request)
        {
            string endpoint = "/2.0/webhooks";
            return await _revolutApiClient.Post<CreateWebhookResp>(endpoint, request);
        }

        public async Task<UpdateWebhookResp> UpdateWebhook(string webhookId,UpdateWebhookReq request)
        {
            string endpoint = $"/2.0/webhooks/{webhookId}";
            return await _revolutApiClient.Patch<UpdateWebhookResp>(endpoint, request);
        }
        public async Task<bool> DeleteWebhook(string webhookId)
        {
            if (string.IsNullOrEmpty(webhookId))
            {
                throw new ArgumentException();
            }

            string endpoint = $"/2.0/webhooks/{webhookId}";
            bool result = await _revolutApiClient.Delete(endpoint);
            return result;
        }

        public async Task<Result<GetWebhookResp>> Rotate(string webhookId, RotateWebhookReq request)
        {
            string endpoint = $"/2.0/webhooks/{webhookId}/rotate-signing-secret";
            return await _revolutApiClient.Post<GetWebhookResp>(endpoint, request);
        }
        private IWebhookPayload DeserializePayload(string jsonPayload, string eventType)
        {
            return eventType switch
            {
                "TransactionStateChanged" => JsonConvert.DeserializeObject<TransactionStageChanged>(jsonPayload),
                "TransactionCreated" => JsonConvert.DeserializeObject<TransactionCreated>(jsonPayload),
                "PayoutLinkStateChanged" => JsonConvert.DeserializeObject<PayoutLinkStateChanged>(jsonPayload),
                "PayoutLinkCreated" => JsonConvert.DeserializeObject<PayoutLinkCreated>(jsonPayload),
                _ => throw new InvalidOperationException($"Unknown event type: {eventType}")
            };
        }
        public async Task<List<GetFailedWebHookEventsResp>> GetFailedWebhookEvents(string webhookId, GetFailedWebhookEventsReq request)
        {
            string endpoint = $"/2.0/webhooks/{webhookId}/failed-events";
            var responseContent = await _revolutApiClient.Get(endpoint); 

            if (!string.IsNullOrEmpty(responseContent))
            {
                var rawList = JsonConvert.DeserializeObject<List<JObject>>(responseContent); 
                var result = rawList.Select(rawObject =>
                {
                    var payloadType = rawObject["payload"]?["event"]?.ToString();
                    var payload = DeserializePayload(rawObject["payload"].ToString(), payloadType);

                    return new GetFailedWebHookEventsResp
                    {
                        Id = rawObject["id"].ToString(),
                        CreatedAt = DateTime.Parse(rawObject["created_at"].ToString()),
                        UpdatedAt = DateTime.Parse(rawObject["updated_at"].ToString()),
                        WebhookId = rawObject["webhook_id"].ToString(),
                        WebhookUrl = rawObject["webhook_url"].ToString(),
                        Payload = payload
                    };
                }).ToList();

                return result;
            }

            return new List<GetFailedWebHookEventsResp>();
        }

    }
}
