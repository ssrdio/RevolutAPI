using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Models.Authorization;

using RevolutAPI.Models.BusinessApi.PayoutLinks;
using RevolutAPI.Models.Shared.Enums;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.BusinessApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevolutAPI.Tests.BusinessApi
{
    public class PayoutLinksApiTest
    {
        private static readonly string PAYOUT_LINK_ID = "";
        private static readonly string ACCOUNT_ID = "";
        private readonly PayoutLinksApiClient _payoutLinksApiClient;

        public PayoutLinksApiTest()
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
            _payoutLinksApiClient = new PayoutLinksApiClient(api);

        }
        [Fact]
        public async void Test_GetPayoutLinks()
        {
            List<PayoutLinkState> states = new List<PayoutLinkState> {PayoutLinkState.cancelled,PayoutLinkState.processed,PayoutLinkState.active };
            GetPayoutLinksReq request = new GetPayoutLinksReq(state:states);
            List<GetPayoutLinksResp> response = await _payoutLinksApiClient.GetPayoutLinks(request);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_GetPayoutLinkWithId()
        {
            GetPayoutLinksResp response = await _payoutLinksApiClient.GetPayoutLink(id:PAYOUT_LINK_ID);
            Assert.NotNull(response);
            
        }

        [Fact]
        public async void Test_CreatePayoutLink()
        {
            
            CreatePayoutLinkReq request = new CreatePayoutLinkReq(counterPartyName: "Jhon Doe",requestId:"80492721-9008-48e0-aac3-e30dc1e74f71",accountId: ACCOUNT_ID, amount:20,currency:"EUR",reference:"Gas3",expiryPeriod:"P5D");
            var response = await _payoutLinksApiClient.CreatePayoutLink(request);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_CanclePayoutLink()
        {
            var result = await _payoutLinksApiClient.CanclePayoutLink(payoutLinkId:PAYOUT_LINK_ID);
            Assert.NotNull(result);
        }

        [Fact]
        public async void Test_GetTransferReasons()
        {
            List<GetTransferReasonsResp> response  = await _payoutLinksApiClient.GetTransferReasons(); 
            Assert.NotNull(response);
        }

    }
}
