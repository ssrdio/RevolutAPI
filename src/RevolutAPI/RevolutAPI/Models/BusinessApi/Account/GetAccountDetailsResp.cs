using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.Account.Objects;
using RevolutAPI.Models.Shared.Enums;
using System.Collections.Generic;

namespace RevolutAPI.Models.BusinessApi.Account
{

    public class GetAccountDetailsResp
    {
        [JsonProperty("iban")]
        public string Iban { get; set; }
        [JsonProperty("bic")]
        public string Bic { get; set; }
        [JsonProperty("account_no")]
        public string AccountNo { get; set; }
        [JsonProperty("sort_code")]
        public string SortCode { get; set; }
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }
        [JsonProperty("beneficiary")]
        public string Beneficiary { get; set; }
        [JsonProperty("beneficiary_address")]
        public BeneficiaryAddress BeneficiaryAddress { get; set; }
        [JsonProperty("bank_country")]
        public string BankCountry { get; set; }
        [JsonProperty("pooled")]
        public bool Pooled { get; set; }
        [JsonProperty("unique_reference")]
        public string UniqueReference { get; set; }
        [JsonProperty("schemes")]
        public List<Schemes> Schemes { get; set; }
        [JsonProperty("estimated_time")]
        public EstimatedTime EstimatedTime { get; set; }
    }
}