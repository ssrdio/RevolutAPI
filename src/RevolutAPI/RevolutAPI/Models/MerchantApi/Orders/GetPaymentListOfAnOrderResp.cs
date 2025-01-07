using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Orders.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class GetPaymentListOfAnOrderResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
