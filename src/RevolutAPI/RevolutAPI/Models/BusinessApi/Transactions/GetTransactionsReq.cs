using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Transactions
{
    public class GetTransactionsReq
    {
        [JsonProperty("from",NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? From { get; set; }
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? To { get; set; }
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public string Account { get; set; }
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public int? Count { get; set; }
        [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
        public string Type {  get; set; }

        public GetTransactionsReq(DateTime? from = null, DateTime? to = null, string account = null, int? count = null, string type = null)
        {
            From = from;
            To = to; 
            Account = account;
            Count = count; 
            Type = type;
           
        }
    }
}
