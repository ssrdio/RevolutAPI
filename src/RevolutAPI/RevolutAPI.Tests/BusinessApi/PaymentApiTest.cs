using System;
using System.Net.Http;
using RevolutAPI.OutCalls;
using Xunit;
using System.Linq;
using RevolutAPI.OutCalls.BusinessApi;
using RevolutAPI.Models.BusinessApi.Payment;
using RevolutAPI.Models.BusinessApi.Account;
using Microsoft.Extensions.Caching.Memory;
using RevolutAPI.Models.Authorization;

namespace RevolutAPI.Tests.BusinessApi
{
    public class PaymentApiTest
    {
        private readonly PaymentApiClient _paymentClient;
        private readonly CounterPartiesApiClient _counterpartyApiClient;
        public readonly AccountApiClient _accountApiClient;

        private readonly IMemoryCache _memoryCache;

        private readonly RefreshAccessTokenModel _refreshAccessTokenModel;

        public PaymentApiTest(RefreshAccessTokenModel refreshAccessTokenModel)
        {
            _refreshAccessTokenModel = refreshAccessTokenModel;

            RevolutApiClient api = new RevolutApiClient(Config.ENDPOINT, _refreshAccessTokenModel, _memoryCache);
            _paymentClient = new PaymentApiClient(api);

            RevolutApiClient api2 = new RevolutApiClient(Config.ENDPOINT, _refreshAccessTokenModel, _memoryCache);
            _counterpartyApiClient = new CounterPartiesApiClient(api2);

            RevolutApiClient api3 = new RevolutApiClient(Config.ENDPOINT, _refreshAccessTokenModel, _memoryCache);
            _accountApiClient = new AccountApiClient(api3);
        }

        [Fact]
        public async void Test_CreatePayment_Valid()
        {
            var req = new CreatePaymentReq
            {
                RequestId = Guid.NewGuid().ToString(),
                AccountId = Config.ACCOUNT_ID,
                Amount = 100,
                Currency = Config.CURRENCY,
                Reference = "Invoice payment #123",
                Receiver = new CreatePaymentReq.ReceiverData
                {
                    CounterpartyId = Config.COUNTERPARTY_ID,
                    AccountId = Config.COUNTERPARTY_ACCOUNT_ID,
                }
            };

            var resp = await _paymentClient.CreatePayment(req);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void Test_GetTransactions_Valid()
        {
            var from = DateTime.Parse("01.06.2018");
            var to = DateTime.Parse("10.06.2018");

            var resp = await _paymentClient.GetTransactions(from, to, TransactionType.CARD_CREDIT);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void Test_GetTransactions()
        {
            var to = DateTime.Parse("04.07.2018");
            string[] types = new string[]
            {
                TransactionType.ATM,
                TransactionType.CARD_PAYMENT,
                TransactionType.CARD_REFUND,
                TransactionType.CARD_CHARGEBACK,
                TransactionType.CARD_CREDIT,
                TransactionType.EXCHANGE,
                TransactionType.TRANSFER,
                TransactionType.LOAN,
                TransactionType.FEE,
                TransactionType.REFUND,
                TransactionType.TOPUP,
                TransactionType.TOPUP_RETURN,
                TransactionType.TAX ,
                TransactionType.TAX_REFUND
            };
            foreach (var type in types)
            {
                var resp = await _paymentClient.GetTransactions(DateTime.MinValue, to, type);

                if (resp.Any())
                {
                    Console.WriteLine(string.Format("Found tranaction for type {0}", type));
                }
            }
        }

        [Fact]
        public async void Test_CheckPaymentStatusByTransactionId()
        {
            var transactions = await _paymentClient.GetTransactions();
            Assert.NotEmpty(transactions);

            var resp = await _paymentClient.CheckPaymentStatusByTransactionId(transactions[0].Id);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void Test_CheckPaymentStatusByRequestId()
        {
            var transactions = await _paymentClient.GetTransactions();
            Assert.NotEmpty(transactions);

            var resp = await _paymentClient.CheckPaymentStatusByRequestId(transactions[0].RequestId);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void Test_Transfer()
        {
            string currency = "GBP";
            var accounts = await _accountApiClient.GetAccounts();

            GetAccountResp accountResp1 = null;
            GetAccountResp accountResp2 = null;

            try
            {
                accountResp1 = accounts.Where(x => x.Currency == currency).First();
                accounts.Remove(accountResp1);
                accountResp2 = accounts.Where(x => x.Currency == currency).First();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception($"Missing account with {currency} currency");
            }

            TransferReq req = new TransferReq
            {
                RequestId = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(),
                SourceAccountId = accountResp1.Id,
                TargetAccountId = accountResp2.Id,
                Amount = 100,
                Currency = currency
            };

            var resp = await _paymentClient.CreateTransfer(req);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void Test_SchedulePayment()
        {
            var req = new SchedulePaymentReq
            {
                RequestId = Guid.NewGuid().ToString(),
                AccountId = Config.ACCOUNT_ID,
                Amount = 100,
                Currency = Config.CURRENCY,
                Reference = "Invoice payment #123",
                ScheduleFor = DateTime.Now.AddDays(2),
                Receiver = new CreatePaymentReq.ReceiverData
                {
                    CounterpartyId = Config.COUNTERPARTY_ID,
                    AccountId = Config.COUNTERPARTY_ACCOUNT_ID,
                }
            };

            var resp = await _paymentClient.SchedulePayment(req);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void Test_CancelPayment()
        {
            var req = new SchedulePaymentReq
            {
                RequestId = Guid.NewGuid().ToString(),
                AccountId = Config.ACCOUNT_ID,
                Amount = 100,
                Currency = Config.CURRENCY,
                Reference = "Invoice payment #123",
                ScheduleFor = DateTime.Now.AddDays(2),
                Receiver = new CreatePaymentReq.ReceiverData
                {
                    CounterpartyId = Config.COUNTERPARTY_ID,
                    AccountId = Config.COUNTERPARTY_ACCOUNT_ID,
                }
            };

            var transaction = await _paymentClient.SchedulePayment(req);
            Assert.NotNull(transaction);

            var resp = await _paymentClient.CancelPayment(transaction.Value.Id);
            Assert.True(resp);
        }
    }
}