using System.Collections.Generic;
using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Webhook;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.MerchantApi;
using Xunit;

namespace RevolutAPI.Tests.MerchantApi
{
    public class WebhookApiTests
    {
        private WebhookApiClient _webhookApiClient;
        private static readonly string WEBHOOK_URL = "";

        public WebhookApiTests()
        {
            _webhookApiClient = new WebhookApiClient(
                new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTAPIVERSION, Config.MERCHANTENDPOINT));
        }

        [Fact]
        public async void TestCreateWebhook_Success()
        {
            CreateWebhookReq request = new CreateWebhookReq
            (
                url: WEBHOOK_URL,
                events: new List<WebhookTypeEnum> { WebhookTypeEnum.ORDER_COMPLETED, WebhookTypeEnum.ORDER_PAYMENT_AUTHENTICATED }
            );

            Result<CreateWebhookResp> webhook = await _webhookApiClient.CreateWebhook(request);
            Assert.True(webhook.Success);

            await _webhookApiClient.DeleteWebhook(webhook.Value.Id);
        }

        [Fact]
        public async void TestGetWebhook_Success()
        {
            string url = WEBHOOK_URL;
            CreateWebhookReq request = new CreateWebhookReq
            (
                url: url,
                events: new List<WebhookTypeEnum> { WebhookTypeEnum.ORDER_COMPLETED }
            );
            Result<CreateWebhookResp> webhook = await _webhookApiClient.CreateWebhook(request);

            WebhookDetailsResp response = await _webhookApiClient.GetWebhook(webhook.Value.Id);

            Assert.NotNull(response);
            Assert.Equal(url, response.Url);

            await _webhookApiClient.DeleteWebhook(webhook.Value.Id);
        }

        [Fact]
        public async void TestGetWebhooks_Success()
        {
            List<WebhooksResp> webhooks = await _webhookApiClient.GetWebhooks();

            Assert.NotNull(webhooks);
        }

        [Fact]
        public async void TestUpdateWebhook_Success()
        {
            string urlOld = WEBHOOK_URL;
            CreateWebhookReq request = new CreateWebhookReq
            (
                url: urlOld,
                events: new List<WebhookTypeEnum> { WebhookTypeEnum.ORDER_COMPLETED }
            );
            var webhook = await _webhookApiClient.CreateWebhook(request);

            WebhookDetailsResp webhookDetails = await _webhookApiClient.GetWebhook(webhook.Value.Id);

            string url = WEBHOOK_URL;
            WebhooksResp webhookUpdate = await _webhookApiClient.UpdateWebhook(webhook.Value.Id, new UpdateWebhookReq
            {
                Url = url,
                Events = new List<WebhookTypeEnum> { WebhookTypeEnum.ORDER_AUTHORISED },
            });

            WebhookDetailsResp newWebhookDetails = await _webhookApiClient.GetWebhook(webhook.Value.Id);

            Assert.NotEqual(newWebhookDetails.Url, webhookDetails.Url);
            Assert.NotEqual(newWebhookDetails.Events, webhookDetails.Events);

            await _webhookApiClient.DeleteWebhook(webhook.Value.Id);
        }

        [Fact]
        public async void TestDeleteWebhook_Success()
        {
            string url = WEBHOOK_URL;
            CreateWebhookReq request = new CreateWebhookReq
            (
                url: url,
                events: new List<WebhookTypeEnum> { WebhookTypeEnum.ORDER_COMPLETED }
            );
            var webhook = await _webhookApiClient.CreateWebhook(request);

            bool isDeleted = await _webhookApiClient.DeleteWebhook(webhook.Value.Id);

            WebhookDetailsResp webhookDetails = await _webhookApiClient.GetWebhook(webhook.Value.Id);

            Assert.True(isDeleted);
            Assert.True(webhookDetails == null);
        }
    }
}
