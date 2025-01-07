using Newtonsoft.Json;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class GetOrderListReq
    {
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedBefore { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FromCreatedDate { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ToCreatedDate { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantOrderExtRef { get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public List<OrderStateEnum> State { get; set; }

        public GetOrderListReq(int limit = 100,
            DateTime? createdBefore = null,
            DateTime? fromCreatedDate = null,
            DateTime? toCreatedDate = null,
            string customerId = null,
            string eamil = null,
            string merchantOrderExtRef = null,
            List<OrderStateEnum> state = null)
        {
            Limit = limit;
            CreatedBefore = createdBefore;
            FromCreatedDate = fromCreatedDate;
            ToCreatedDate = toCreatedDate;
            CustomerId = customerId;
            Email = eamil;
            MerchantOrderExtRef = merchantOrderExtRef;
            State = state;
        }
    }
}
