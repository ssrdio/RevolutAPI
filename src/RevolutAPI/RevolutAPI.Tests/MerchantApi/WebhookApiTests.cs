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

        public WebhookApiTests()
        {
            _webhookApiClient = new WebhookApiClient(
                new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTENDPOINT));
        }

        [Fact]
        public async void TestCreateWebhook_Success()
        {
            Result<CreateWebhookResp> webhook = await _webhookApiClient.CreateWebhook(new CreateWebhookReq
            {
                Url = "https://test-revolut-1.ssrd.io",
                Events = new List<WebhookTypeEnum> { WebhookTypeEnum.ORDER_COMPLETED },
            });

            Assert.True(webhook.Success);

            await _webhookApiClient.DeleteWebhook(webhook.Value.Id);
        }

        [Fact]
        public async void TestGetWebhook_Success()
        {
            string url = "https://test-revolut-2.ssrd.io";
            Result<CreateWebhookResp> webhook = await _webhookApiClient.CreateWebhook(new CreateWebhookReq
            {
                Url = url,
                Events = new List<WebhookTypeEnum> { WebhookTypeEnum.ORDER_COMPLETED },
            });

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
            string urlOld = "https://test-revolut-3.ssrd.io";
            var webhook = await _webhookApiClient.CreateWebhook(new CreateWebhookReq
            {
                Url = urlOld,
                Events = new List<WebhookTypeEnum> { WebhookTypeEnum.ORDER_COMPLETED },
            });

            WebhookDetailsResp webhookDetails = await _webhookApiClient.GetWebhook(webhook.Value.Id);

            string url = "https://test-revolut-4.ssrd.io";
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
            string url = "https://test-revolut-5.ssrd.io";
            var webhook = await _webhookApiClient.CreateWebhook(new CreateWebhookReq
            {
                Url = url,
                Events = new List<WebhookTypeEnum> { WebhookTypeEnum.ORDER_COMPLETED },
            });

            bool isDeleted = await _webhookApiClient.DeleteWebhook(webhook.Value.Id);

            WebhookDetailsResp webhookDetails = await _webhookApiClient.GetWebhook(webhook.Value.Id);

            Assert.True(isDeleted);
            Assert.True(webhookDetails == null);
        }
    }
}
