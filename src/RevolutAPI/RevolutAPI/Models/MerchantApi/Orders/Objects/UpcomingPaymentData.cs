using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class UpcomingPaymentData
    {
        [JsonProperty("date")]
        public DateTime DateTime { get; set; }
        [JsonProperty("payment_method_id")]
        public string PaymentMethodId { get; set; }
    }
}
