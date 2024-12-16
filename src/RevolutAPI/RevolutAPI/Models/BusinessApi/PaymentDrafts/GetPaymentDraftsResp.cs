using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PaymentDrafts
{
    public class GetPaymentDraftsResp
    {
        [JsonProperty("payment_orders")]
        public List<PaymentOrders> PaymentOrders { get; set; }
    }

    public class PaymentOrders
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("scheduled_for")]
        public DateTime ScheduledFor { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("payments_count")]
        public int PaymentsCount { get; set; }
    }
}
