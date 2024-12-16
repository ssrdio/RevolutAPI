using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Orders.Objects;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class UpdateOrderReq : CreateOrderReq
    {
        public UpdateOrderReq(int amount, string currency,
        string settlementCurrency = null,
        string description = null,
        Customer customer = null,
        string enforceChallenge = "automatic",
        List<LineItem> lineItems = null,
        Shipping shipping = null,
        string captureMode = "automatic",
        string cancelAuthorisedAfter = null,
        string locationId = null,
        IndustryData industryData = null,
        MerchantOrderData merchantOrderData = null,
        UpcomingPaymentData upcomingPaymentData = null,
        string redirectUrl = null,
        Dictionary<string, string> metadata = null)
        : base(amount, currency, settlementCurrency, description, customer, enforceChallenge,
               lineItems, shipping, captureMode, cancelAuthorisedAfter, locationId,
               industryData, merchantOrderData, upcomingPaymentData, redirectUrl, metadata)
        {
        }
    }
}
