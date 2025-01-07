using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Orders.Objects;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class CreateOrderReq
    {
        [JsonIgnore]
        public double Amount { get; set; }

        [JsonProperty("amount")]
        public long InternalAmount
        {
            get
            {
                return Convert.ToInt64(Amount * 100);
            }
        }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("settlement_currency", NullValueHandling = NullValueHandling.Ignore)]
        public string SettlementCurrency { get; set; }
        public string Description { get; set; }
        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        public Customer Customer { get; set; }
        [JsonProperty("enforce_challenge")]
        public string EnforceChallenge { get; set; }
        [JsonProperty("line_items", NullValueHandling = NullValueHandling.Ignore)]
        public List<LineItem> LineItems { get; set; }
        [JsonProperty("shipping", NullValueHandling = NullValueHandling.Ignore)]
        public Shipping Shipping { get; set; }
        [JsonProperty("capture_mode")]
        public string CaptureMode { get; set; }
        [JsonProperty("cancel_authorised_after", NullValueHandling = NullValueHandling.Ignore)]
        public string CancelAuthorisedAfter { get; set; }
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; set; }
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Metadata { get; set; }
        [JsonProperty("industry_data", NullValueHandling = NullValueHandling.Ignore)]
        public IndustryData IndustryData { get; set; }
        [JsonProperty("merchant_order_data", NullValueHandling = NullValueHandling.Ignore)]
        public MerchantOrderData MerchantOrderData { get; set; }
        [JsonProperty("upcoming_payment_data", NullValueHandling = NullValueHandling.Ignore)]
        public UpcomingPaymentData UpcomingPaymentData { get; set; }
        [JsonProperty("redirect_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RedirectUrl { get; set; }

        public CreateOrderReq(double amount, string currency,
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
        {
            Amount = amount;
            Currency = currency;

            SettlementCurrency = settlementCurrency;
            Description = description;
            Customer = customer;
            EnforceChallenge = enforceChallenge;
            LineItems = lineItems;
            Shipping = shipping;
            CaptureMode = captureMode;
            CancelAuthorisedAfter = cancelAuthorisedAfter;
            LocationId = locationId;
            MerchantOrderData = merchantOrderData;
            RedirectUrl = redirectUrl;
            Metadata = metadata;
        }
    }
}
