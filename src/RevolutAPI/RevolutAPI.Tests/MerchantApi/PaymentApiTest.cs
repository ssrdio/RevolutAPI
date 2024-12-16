using RevolutAPI.Helpers;
using RevolutAPI.Models.MerchantApi.Customers;
using RevolutAPI.Models.MerchantApi.Payments;
using RevolutAPI.Models.MerchantApi.Payments.Objects;
using RevolutAPI.OutCalls;
using RevolutAPI.OutCalls.MerchantApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevolutAPI.Tests.MerchantApi
{
    public class PaymentApiTest
    {
        private readonly MerchantPaymentsApiClient _merchantPaymentsApiClient;
        private static readonly string ORDER_ID = "";
        private static readonly string CUSTOMERS_PAYMENT_METHOD_ID = "";
        public PaymentApiTest()
        {
            _merchantPaymentsApiClient = new MerchantPaymentsApiClient(new RevolutSimpleClient(Config.MERCHANTAPIKEY, Config.MERCHANTAPIVERSION, Config.MERCHANTENDPOINT));
        }

        [Fact]
        public async void PayForAnOrder()
        {
          SavedPaymentMethod savedPaymentMethod = new SavedPaymentMethod
          (
              id: "675fee58-7bf1-af7a-9eb2-1dfbd3c066fc",
              type: "card",
              initiator: "merchant"

          );
          PayForAnOrderReq req = new PayForAnOrderReq ( savedPaymentMethod = savedPaymentMethod );
          Result<PayForAnOrderResp> result = await _merchantPaymentsApiClient.ConfirmOrder(ORDER_ID, req);
          Assert.NotNull(result);
        }

        [Fact]
        public async void GetPaymentDetails()
        {
            GetPaymentDetailsResp result = await _merchantPaymentsApiClient.RetrievePaymentDetails(ORDER_ID);
            Assert.NotNull(result);
        }
    }
}
