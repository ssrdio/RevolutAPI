using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using RevolutAPI.OutCalls;
using System.Net.Http;
using RevolutAPI.Models.Counterparties;
using RevolutAPI.Helpers;

namespace RevolutAPI.Tests
{
    public class CounterpartiesApiTest
    {
        private readonly CounterPartiesApiClient _counterpartiesApiClient;

        public CounterpartiesApiTest()
        {
            HttpClient httpClient = new HttpClient();
            RevolutApiClient api = new RevolutApiClient(httpClient, Config.ENDPOINT, Config.TOKEN);
            _counterpartiesApiClient = new CounterPartiesApiClient(api);
        }

        [Fact]
        public async void TestGetCounterparties_Success()
        {
            List<GetCounterpartyResp> resp = await _counterpartiesApiClient.GetCounterparties();
            Assert.NotNull(resp);
        }

        [Fact]
        public async void TestGetCounterparty_Success()
        {
            var counterparties = await _counterpartiesApiClient.GetCounterparties();
            Assert.NotEmpty(counterparties);

            GetCounterpartyResp resp = await _counterpartiesApiClient.GetCounterparty(counterparties[0].Id);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void TestAddCounterparty_Success()
        {
            string phone = "+4412345678908";

            var counterparties = await _counterpartiesApiClient.GetCounterparties();
            if(counterparties.Exists(x => x.Phone == phone))
            {
                throw new Exception($"Counterparty with {phone} alredy exsists");
            }

            AddCounterpartyReq req = new AddCounterpartyReq
            {
                ProfileType = ProfileType.PERSONAL,
                Name = "John Smith",
                Phone = phone
            };

            Result<AddCounterpartyResp> resp = await _counterpartiesApiClient.CreateCounterparty(req);
            Assert.NotNull(resp);

            var resp2 = await _counterpartiesApiClient.DeleteCounterparty(resp.Value.Id);
            Assert.True(resp2);
        }

        [Fact]
        public async void TestAddNonRevolutCounterparty_Success()
        {
            AddNonRevolutCounterpartyReq req = new AddNonRevolutCounterpartyReq
            {
                CompanyName = "John Smith Co.",
                BankCountry = "GB",
                Currency = "GBP",
                AccountNo = "12345678",
                SortCode = "223344",
                Email = "john@smith.co",
                Phone = "+447771234455",
                Address = new AddNonRevolutCounterpartyReq.AddressData
                {
                    StreetLine1 = "1 Canada Square",
                    StreetLine2 = "Canary Wharf",
                    Region = "East End",
                    Postcode = "E115AB",
                    City = "London",
                    Country = "GB",
                }
            };

            Result<AddNonRevolutCounterpartyResp>  resp = await _counterpartiesApiClient.CreateNonRevolutCounterparty(req);
            Assert.NotNull(resp);
        }

        [Fact]
        public async void TestDeleteCounterparty_Success()
        {
            string phone = "+4412345678909";
            string counterpartyId;

            var counterparties = await _counterpartiesApiClient.GetCounterparties();
            Assert.NotNull(counterparties);

            try
            {
                counterpartyId = counterparties.Find(x => x.Phone == phone).Id;
            }
            catch(NullReferenceException)
            {
                AddCounterpartyReq req = new AddCounterpartyReq
                {
                    ProfileType = ProfileType.PERSONAL,
                    Name = "John Smith",
                    Phone = phone
                };

                var counterparty = await _counterpartiesApiClient.CreateCounterparty(req);
                Assert.NotNull(counterparty);

                counterpartyId = counterparty.Value.Id;
            }

            bool resp = await _counterpartiesApiClient.DeleteCounterparty(counterpartyId);
            Assert.True(resp);
        }


    }
}
