using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyModel;
using RevolutAPI.Models.Account;
using RevolutAPI.OutCalls;
using RichardSzalay.MockHttp;
using Xunit;

namespace RevolutAPI.Tests
{
    public class AccountApiTest
    {
        private static readonly string ACCOUNT_ID = ""; 
        
        private readonly AccountApiClient _accountClient;
        private readonly MockHttpMessageHandler _mockHttp;

        public AccountApiTest()
        {
            var httpClient = new HttpClient();
            RevolutApiClient api = new RevolutApiClient(httpClient, Config.ENDPOINT, Config.TOKEN);
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
