using RevolutAPI.OutCalls.MerchantApi;
using RevolutAPI.OutCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevolutAPI.Models.MerchantApi.Orders;
using Xunit;
using RevolutAPI.Models.MerchantApi.Payouts;

namespace RevolutAPI.Tests.MerchantApi
{
    public class PayoutsApiTest
    {
        private readonly  PayoutsApiClient _payoutsApiClient;
        private static readonly string PAYOUT_ID = "";

        public PayoutsApiTest()
        {
            _payoutsApiClient = new PayoutsApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTAPIVERSION, Config.MERCHANTENDPOINT));
        }

        [Fact]
        public async void TestRetrievePayoutList()
        {
            List<string> states = new List<string> {"completed","failed"};
            GetPayoutReq req = new GetPayoutReq(state:states,toCreated:DateTime.UtcNow);
            List<GetPayoutsResp> payouts = await _payoutsApiClient.GetPayouts(req);

            Assert.NotNull(payouts);
        }
        [Fact]
        public async void TestRetrievePayout()
        {
            
            GetPayoutsResp payout = await _payoutsApiClient.GetPayout(PAYOUT_ID);
            Assert.NotNull(payout);
        }
    }
}
