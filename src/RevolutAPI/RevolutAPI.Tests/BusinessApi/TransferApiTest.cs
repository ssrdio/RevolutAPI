using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Helpers;
using RevolutAPI.Models.Authorization;
using RevolutAPI.Models.BusinessApi.PayoutLinks;
using RevolutAPI.Models.BusinessApi.Transfer;
using RevolutAPI.Models.Shared;
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
    public class TransferApiTest
    {
        private readonly TransferApiClient _transferClient;
        private static readonly string SOURCE_ACCOUNT_ID = "";
        private static readonly string TARGET_ACCOUNT_ID = "";
        private static readonly string COUNTERPARTY_ID = "";
        public TransferApiTest()
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
            _transferClient = new TransferApiClient(api);
        }

        [Fact]
        public async void Test_TransferMoneyBetweenAccounts()
        {
            TransferBetweenAccountsReq request = new TransferBetweenAccountsReq("fe532908-8493-4007-9008-c46ee0f11851", SOURCE_ACCOUNT_ID, TARGET_ACCOUNT_ID, 444,"GBP", "Test move money between accounts");
            Result<TransferBetweenAccountsResp> response = await _transferClient.TransferMoneyBetweenAccounts(request);
            
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_TransferToAnotherAccountOrCard()
        {
            Receiver receiver = new Receiver(COUNTERPARTY_ID, null,null);
            TransferToAnotherAccountOrCardReq request = new TransferToAnotherAccountOrCardReq("fe532908-8493-4007-9008-c46ee0f11859", SOURCE_ACCOUNT_ID, receiver, 19, "GBP", "Money for Gas", null, null);
            Result<TransferToAnotherAccountOrCardResp> response = await _transferClient.TransferToAnotherAccountOrCard(request);
            Assert.NotNull(response);
        }
    }
}
