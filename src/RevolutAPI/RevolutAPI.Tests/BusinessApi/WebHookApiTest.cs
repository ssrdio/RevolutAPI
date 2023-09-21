using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Models.Authorization;
using RevolutAPI.Models.BusinessApi.WebHook;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.BusinessApi;
using Xunit;

namespace RevolutAPI.Tests.BusinessApi
{
    public class WebHookApiTest
    {
        private readonly WebHookApiClient webHookApiClient;

        public WebHookApiTest()
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
            webHookApiClient = new WebHookApiClient(api);
        }

        [Theory]
        [InlineData("https://bot.test.si")]
        public async void Test_CreateWebHook_Success(string url)
        {
            AddWebHookReq req = new AddWebHookReq
            {
                Url = url
            };
            Helpers.Result<WebHookResp> resp = await webHookApiClient.CreateWebHook(req);
            Assert.True(resp.Success);
        }

        [Theory]
        [InlineData("http://bot.test.si")]
        public async void Test_CreateWebHook_InvalidUriScheme(string url)
        {
            AddWebHookReq req = new AddWebHookReq
            {
                Url = url
            };
            Helpers.Result<WebHookResp> resp = await webHookApiClient.CreateWebHook(req);
            Assert.False(resp.Success);
        }
    }
}
