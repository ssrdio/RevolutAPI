using Newtonsoft.Json;
using RevolutAPI.Models.MerchantApi.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Card.Objects
{
    public class CardSpendingLimits
    {
        [JsonProperty("single")]
        public CardSpendingAmount Single { get; set; }
        [JsonProperty("day")]
        public CardSpendingAmount Day { get; set; }
        [JsonProperty("week")]
        public CardSpendingAmount Week { get; set; }
        [JsonProperty("mont")]
        public CardSpendingAmount Month { get; set; }
        [JsonProperty("quarter")]
        public CardSpendingAmount Quarter { get; set; }
        [JsonProperty("year")]
        public CardSpendingAmount Year { get; set; }
        [JsonProperty("all_time")]
        public CardSpendingAmount AllTime { get; set; }
    }
 
}
