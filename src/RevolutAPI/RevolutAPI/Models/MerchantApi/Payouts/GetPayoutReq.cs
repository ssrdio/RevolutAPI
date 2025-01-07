using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Payouts
{
    public class GetPayoutReq
    {
        [JsonProperty("currency", NullValueHandling =NullValueHandling.Ignore)]
        public string Currency {  get; set; }
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        [JsonProperty("from_created_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FromCreatedDate { get; set; }
        [JsonProperty("to_created_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ToCreatedDate { get; set; }
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> State { get; set; } 

        public GetPayoutReq(string currency = null, 
            int? limit = null, 
            DateTime? fromCreated = null, 
            DateTime? toCreated = null, 
            List<string> state = null)
        {
            Currency = currency;
            Limit = limit;
            FromCreatedDate = fromCreated;
            ToCreatedDate = toCreated;
            State = state;
        }
    }
}
