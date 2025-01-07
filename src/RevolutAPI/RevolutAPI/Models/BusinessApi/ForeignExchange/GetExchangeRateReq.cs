using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.ForeignExchange
{
    public class GetExchangeRateReq
    {
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }

        public GetExchangeRateReq(string from, string to , double amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
