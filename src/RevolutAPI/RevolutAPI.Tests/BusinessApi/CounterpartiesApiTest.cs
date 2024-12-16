using System;
using System.Collections.Generic;
using Xunit;
using RevolutAPI.OutCalls;
using System.Net.Http;
using RevolutAPI.Helpers;
using RevolutAPI.OutCalls.BusinessApi;
using RevolutAPI.Models.BusinessApi.Counterparties;
using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Models.Authorization;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace RevolutAPI.Tests.BusinessApi
{
    public class CounterpartiesApiTest
    {
        private readonly CounterPartiesApiClient _counterpartiesApiClient;
        private static readonly string COUNTERPARTY_ID = "";

        public CounterpartiesApiTest()
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

            _counterpartiesApiClient = new CounterPartiesApiClient(api);
        }

        [Fact]
        public async void TestGetCounterparties_Success()
        {
            GetCounterpartiesReq request = new GetCounterpartiesReq(createdBefore:DateTime.UtcNow);
            List<GetCounterpartyResp> resp = await _counterpartiesApiClient.GetCounterparties(request);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void TestGetCounterparty_Success()
        {
            GetCounterpartiesReq request = new GetCounterpartiesReq(createdBefore: DateTime.UtcNow);
            var counterparties = await _counterpartiesApiClient.GetCounterparties(request);
            Assert.NotEmpty(counterparties);

            GetCounterpartyResp resp = await _counterpartiesApiClient.GetCounterparty(counterparties[0].Id);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void TestAddCounterparty_Success()
        {
            CreateCounterpartyReq req = new CreateCounterpartyReq(companyName:"TestCompany",bankCountry:"FR",currency:"EUR",iban: "FR1420041010050500013M02606");
           
            Result<CreateCounterpartyResp> resp = await _counterpartiesApiClient.CreateCounterparty(req);
            Assert.NotNull(resp);
        }


        [Fact]
        public async void TestDeleteCounterparty_Success()
        {
            bool resp = await _counterpartiesApiClient.DeleteCounterparty(COUNTERPARTY_ID);
            Assert.True(resp);
        }


    }
}
