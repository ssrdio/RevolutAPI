using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Models.Authorization;
using RevolutAPI.Models.BusinessApi.Account;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.BusinessApi;
using RichardSzalay.MockHttp;
using Xunit;

namespace RevolutAPI.Tests.BusinessApi
{
    public class AccountApiTest
    {
        private static readonly string ACCOUNT_ID = "";

        private readonly AccountApiClient _accountClient;
        private readonly MockHttpMessageHandler _mockHttp;

        private readonly IMemoryCache _memoryCache;

        private RefreshAccessTokenModel _refreshAccessTokenModel;

        public AccountApiTest(RefreshAccessTokenModel refreshAccessTokenModel, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

            _refreshAccessTokenModel = refreshAccessTokenModel;

            RevolutApiClient api = new RevolutApiClient(Config.ENDPOINT, _refreshAccessTokenModel, _memoryCache);
            _accountClient = new AccountApiClient(api);
        }

        [Fact]
        public async void TestGetAccounts_Success()
        {
            List<GetAccountResp> resp = await _accountClient.GetAccounts();
            Assert.NotNull(resp);
        }

        [Fact]
        public async void TestGetAccount_NullArg()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _accountClient.GetAccount(null));
        }

        [Fact]
        public async void TestGetAccount_EmptyArg()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _accountClient.GetAccount(string.Empty));
        }

        [Fact]
        public async void TestGetAccount_ValidId_Success()
        {
            GetAccountResp resp = await _accountClient.GetAccount(ACCOUNT_ID);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void TestGetAccount_InalidId()
        {
            GetAccountResp resp = await _accountClient.GetAccount("000");
            Assert.Null(resp);
        }

        [Fact]
        public async void TestGetAccountDetails_NullArg()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _accountClient.GetAccountDetails(null));
        }

        [Fact]
        public async void TestGetAccountDetails_EmptyArg()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => _accountClient.GetAccountDetails(string.Empty));
        }

        [Fact]
        public async void TestGetAccountDetails_Success()
        {
            var resp = await _accountClient.GetAccountDetails(ACCOUNT_ID);
            Assert.NotNull(resp);
        }
    }
}
