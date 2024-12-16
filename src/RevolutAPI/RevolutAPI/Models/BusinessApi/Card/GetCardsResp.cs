using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.Card.Objects;
using RevolutAPI.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Card
{
    public class GetCardsResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("last_digits")]
        public string LastDigits { get; set; }
        [JsonProperty("expiry")]
        public string Expiry { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("virtual")]
        public bool Virtual { get; set; }
        [JsonProperty("product")]
        public CardProduct Product { get; set; }
        [JsonProperty("acounts")]
        public List<string> Accounts {  get; set; }
        [JsonProperty("categoires")]
        public List<CardCategoriesEnum> Categories { get; set; }
        [JsonProperty("spend_program")]
        public CardSpendProgram SpendProgram { get; set; }
        [JsonProperty("spending_limits")]
        public CardSpendingLimits SpendingLimits { get; set; }
        [JsonProperty("holer_id")]
        public string HolderId { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
  
}
