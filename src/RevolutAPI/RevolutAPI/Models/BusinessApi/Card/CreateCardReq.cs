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
    public class CreateCardReq
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        [JsonProperty("virtual")]
        public bool Virtual { get; set; }
        [JsonProperty("holder_id")]
        public string HolderId { get; set; }
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }
        [JsonProperty("accounts",NullValueHandling =NullValueHandling.Ignore)]
        public List<string> Accounts { get; set; }
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<CardCategoriesEnum> Categories { get; set; }
        [JsonProperty("spending_limits", NullValueHandling = NullValueHandling.Ignore)]
        public CardSpendingLimits SpendingLimits { get; set; }

        public CreateCardReq(string requestId,
            bool virt,
            string holderId,
            string label = null,
            List<string> accounts = null, 
            List<CardCategoriesEnum> categories = null,
            CardSpendingLimits spendingLimits = null)
        {
            RequestId = requestId;
            Virtual = virt;
            HolderId = holderId;
            Label = label;
            Accounts = accounts;
            SpendingLimits = spendingLimits;
            Categories = categories;
        }
    }
}
