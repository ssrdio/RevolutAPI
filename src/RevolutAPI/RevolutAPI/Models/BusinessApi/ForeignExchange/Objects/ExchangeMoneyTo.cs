using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.ForeignExchange.Objects
{
    public class ExchangeMoneyTo
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public double? Amount { get; set; }

        public ExchangeMoneyTo(string accountId, string currenc, double? amount = null)
        {
            AccountId = accountId;
            Currency = currenc;
            Amount = amount;
        }
    }
}
