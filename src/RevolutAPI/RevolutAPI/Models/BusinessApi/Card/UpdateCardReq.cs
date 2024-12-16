using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.Card.Objects;
using RevolutAPI.Models.Shared.Enums;

namespace RevolutAPI.Models.BusinessApi.Card
{
    public class UpdateCardReq
    {
        [JsonProperty("label",NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<CardCategoriesEnum> Categories { get; set; }
        [JsonProperty("spending_limits", NullValueHandling = NullValueHandling.Ignore)]
        public CardSpendingLimits SpendingLimits { get; set; }

        public UpdateCardReq(string label = null, List<CardCategoriesEnum> categoreis = null, CardSpendingLimits spendingLimits = null)
        {
            Label = label;
            Categories = categoreis;
            SpendingLimits= spendingLimits;
        }
    }
}
