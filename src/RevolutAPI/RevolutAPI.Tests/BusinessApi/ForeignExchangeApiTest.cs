using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Models.Authorization;
using RevolutAPI.OutCalls.BusinessApi;
using RevolutAPI.OutCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutAPI.Models.BusinessApi.PayoutLinks;
using Xunit;
using RevolutAPI.Models.BusinessApi.ForeignExchange;
using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.ForeignExchange.Objects;

namespace RevolutAPI.Tests.BusinessApi
{
    public  class ForeignExchangeApiTest
    {
        private static readonly string ACCOUNT_ID = ""; 
        private static readonly string ACCOUNT2_ID = ""; 
        private readonly ForeignExchangeApiClient _exchangeApiClient;

        public ForeignExchangeApiTest()
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
            _exchangeApiClient = new ForeignExchangeApiClient(api);

        }

        [Fact]
        public async void Test_GetExchangeRate()
        {
            GetExchangeRateReq exchangeRateRequest = new GetExchangeRateReq("GBP","EUR",10);
            GetExchangeRateResp response = await _exchangeApiClient.GetExchangeRate(exchangeRateRequest);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_ExchangeMoney()
        {
            ExchangeMoneyFrom from = new ExchangeMoneyFrom(ACCOUNT_ID,"GBP",150);
            ExchangeMoneyTo to = new ExchangeMoneyTo(ACCOUNT2_ID,"EUR");
            ExchangeMoneyReq request = new ExchangeMoneyReq(from,to,reference:"ExhcangeTest", requestId:"9624bbc4-dac4-42b7-a02f-ec0f04e021mn");

            Result<ExchangeMoneyResp> response = await _exchangeApiClient.Exchange(request);
            Assert.NotNull(response);
        }
    }
}
