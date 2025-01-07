using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.PaymentDrafts.Objects;
using RevolutAPI.Models.MerchantApi.Orders;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PaymentDrafts
{
    public class GetPaymentDraftResp
    {
        [JsonProperty("scheduled_for")]
        public DateTime ScheduledFor { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("payments")]
        public List<GetPaymentDraftPayment> Payments { get; set; }

    }
    
}
