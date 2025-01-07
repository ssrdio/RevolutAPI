using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.ForeignExchange.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.ForeignExchange
{
    public class ExchangeMoneyReq
    {
        [JsonProperty("from")]
        public ExchangeMoneyFrom From {  get; set; }
        [JsonProperty("to")]
        public ExchangeMoneyTo To { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        public ExchangeMoneyReq(ExchangeMoneyFrom exchangeMoneyFrom, ExchangeMoneyTo exchangeMoneyTo, string requestId, string reference = null)
        {
            From = exchangeMoneyFrom;
            To = exchangeMoneyTo;
            Reference = reference;
            RequestId = requestId;
        }
    }
 
    
}
