using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Models.Authorization;
using RevolutAPI.OutCalls.BusinessApi;
using RevolutAPI.OutCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutAPI.Models.BusinessApi.WebHookV2;
using RevolutAPI.Helpers;
using Xunit;
using RevolutAPI.Models.Shared.Enums;

namespace RevolutAPI.Tests.BusinessApi
{
    public class WebhookApiTest
    {
        private readonly WebhookApiClient _webhookClient;
        private static readonly string WEBHOOK_URL = "";
        private static readonly string WEBHOOK_ID = "";


        public WebhookApiTest()
        {
            RefreshAccessTokenModel refreshAccessTokenModel = new RefreshAccessTokenModel
            {
                CertificatePassword = Config.CertificatePassword,
                ClientId = Config.ClientId,
                PrivateCert = Config.PrivateCert,
                RefreshToken = Config.RefreshToken,
                Issuer = Config.Issuer,
            };
            MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

            RevolutApiClient api = new RevolutApiClient(Config.ENDPOINT, refreshAccessTokenModel, memoryCache);
            _webhookClient = new WebhookApiClient(api);
        }

        [Fact]
        public async void Test_CreateWebhook()
        {
            List<WebhookEvents> events = new List<WebhookEvents> { WebhookEvents.PayoutLinkCreated,WebhookEvents.TransactionCreated,WebhookEvents.TransactionStateChanged };
            CreateWebhookReq request = new CreateWebhookReq(WEBHOOK_URL, events);
            Result<CreateWebhookResp> response = await _webhookClient.CreateWebhook(request);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_GetWebhooks()
        {
            List<GetWebhooksResp> response = await _webhookClient.GetWebhooks();
            Assert.NotNull(response);
        }
        [Fact]
        public async void Test_GetWebhook()
        {
            GetWebhookResp response = await _webhookClient.GetWebhook(WEBHOOK_ID);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_UpdateWebhook()
        {
            List<WebhookEvents> events = new List<WebhookEvents> { WebhookEvents.TransactionCreated,WebhookEvents.PayoutLinkCreated };
            UpdateWebhookReq request = new UpdateWebhookReq(WEBHOOK_URL, events);
            UpdateWebhookResp response = await _webhookClient.UpdateWebhook(WEBHOOK_ID, request);
            Assert.NotNull(response);
        }
        [Fact]
        public async void Test_DeleteWebhook()
        {
            var response = await _webhookClient.DeleteWebhook(WEBHOOK_ID);
            Assert.True(response);
        }

        [Fact]
        public async void Test_RotateWebhook()
        {
            RotateWebhookReq request = new RotateWebhookReq("P5D");
            Result<GetWebhookResp> response = await _webhookClient.Rotate(WEBHOOK_ID, request);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_GetFailedWebhookEvents()
        {
            GetFailedWebhookEventsReq request = new GetFailedWebhookEventsReq(null, null);
            var response = await _webhookClient.GetFailedWebhookEvents(WEBHOOK_ID, request);
            Assert.NotNull(response);
        }
    }
}
