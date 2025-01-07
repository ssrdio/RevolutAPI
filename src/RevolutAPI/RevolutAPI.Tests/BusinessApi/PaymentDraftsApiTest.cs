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
using RevolutAPI.Models.BusinessApi.PaymentDrafts;
using RevolutAPI.Models.Shared;
using RevolutAPI.Helpers;
using RevolutAPI.Models.BusinessApi.PaymentDrafts.Objects;

namespace RevolutAPI.Tests.BusinessApi
{
    public class PaymentDraftsApiTest
    {
        private static readonly string PAYOUT_LINK_ID = "";
        private static readonly string ACCOUNT_ID = ""; 
        private static readonly string COUNTERPARTY_ID = ""; 
        private static readonly string PAYMENTDRAFT_ID = "";
        private readonly PaymentDraftsApiClient _paymentDraftApiClient;

        public PaymentDraftsApiTest()
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
            _paymentDraftApiClient = new PaymentDraftsApiClient(api);
            
        }

        [Fact]
        public async void Test_GetPaymentDrafts()
        {
            GetPaymentDraftsResp response = await _paymentDraftApiClient.GetPaymentDrafts();
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_GetPaymentDraft()
        {
            GetPaymentDraftResp response = await _paymentDraftApiClient.GetPaymentDraft(PAYMENTDRAFT_ID);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_CreatePaymentDraft()
        {
            Receiver receiver = new Receiver(COUNTERPARTY_ID,null,null);
            CreatePaymentDraftPayments payment1 = new CreatePaymentDraftPayments(ACCOUNT_ID, receiver, 10, "GBP", "Car wash");
            CreatePaymentDraftPayments payment2= new CreatePaymentDraftPayments(ACCOUNT_ID, receiver, 10, "GBP", "House clean");
            List<CreatePaymentDraftPayments> payments = new List<CreatePaymentDraftPayments> { payment1,payment2 };
            CreatePaymentDraftReq request = new CreatePaymentDraftReq(title:"PaymentDraft for house cleaning  to John Smith Co.",scheduleFor: DateTime.Now.AddDays(1),payments: payments);
            Result<CreatePaymentDraftResp> response = await _paymentDraftApiClient.CreatePaymentDraft(request);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_DeletePaymentDraft()
        {
            var response = await _paymentDraftApiClient.DeletePaymentDraft(PAYMENTDRAFT_ID);
            Assert.NotNull(response);
        }

      
    }
}
