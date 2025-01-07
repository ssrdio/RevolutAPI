using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.ForeignExchange.Objects;
using RevolutAPI.Models.MerchantApi.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.ForeignExchange
{
    public class GetExchangeRateResp
    {
        [JsonProperty("from")]
        public AmountAndCurrency From { get; set; }
        [JsonProperty("to")]
        public AmountAndCurrency To { get; set; }
        [JsonProperty("rate")]
        public double Rate { get; set; }
        [JsonProperty("fee")]
        public AmountAndCurrency Fee { get; set; }
        [JsonProperty("rate_date")]
        public DateTime RateDate { get; set; }
    }
}
