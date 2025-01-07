using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Payments.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Payments
{
    public class PayForAnOrderReq
    {
        [JsonProperty("saved_payment_method")]
        public SavedPaymentMethod SavedPaymentMethod { get; set; }
        public PayForAnOrderReq(SavedPaymentMethod savedPaymentMethod)
        {
            SavedPaymentMethod = savedPaymentMethod;
        }

    }
}
