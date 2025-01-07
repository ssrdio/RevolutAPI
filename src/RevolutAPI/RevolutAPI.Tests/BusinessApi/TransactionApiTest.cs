using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Models.Authorization;
using RevolutAPI.OutCalls.BusinessApi;
using RevolutAPI.OutCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutAPI.Models.BusinessApi.Account;
using Xunit;
using RevolutAPI.Models.BusinessApi.Transactions;


namespace RevolutAPI.Tests.BusinessApi
{
    public class TransactionApiTest
    {
        private readonly TransactionApiClient _transactionClient;
        private static readonly string TRANSACTION_ID = "";
        public TransactionApiTest()
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
            _transactionClient = new TransactionApiClient(api);
        }


        [Fact]
        public async void Test_GetTransactions()
        {
            GetTransactionsReq request = new GetTransactionsReq();
            List<GetTransactionsResp> resp = await _transactionClient.GetTransactions(request);
            Assert.NotNull(resp);
        }
        [Fact]
        public async void Test_GetTransaction()
        {
            GetTransactionsResp resp = await _transactionClient.GetTransaction(TRANSACTION_ID);
            Assert.NotNull(resp);
        }
    }
}
