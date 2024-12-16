using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.Counterparties.Objects;
using RevolutAPI.Models.Shared;

namespace RevolutAPI.Models.BusinessApi.Counterparties
{
    public class CreateCounterpartyReq
    {
        [JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }
        [JsonProperty("profile_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfileType { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("individual_name", NullValueHandling = NullValueHandling.Ignore)]
        public IndividualName IndividualName { get; set; }
        [JsonProperty("bank_country", NullValueHandling = NullValueHandling.Ignore)]
        public string BankCountry { get; set; }
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }
        [JsonProperty("revtag", NullValueHandling = NullValueHandling.Ignore)]
        public string Revtag { get; set; }
        [JsonProperty("account_no", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNo { get; set; }
        [JsonProperty("iban", NullValueHandling = NullValueHandling.Ignore)]
        public string Iban  { get; set; }
        [JsonProperty("sort_code", NullValueHandling = NullValueHandling.Ignore)]
        public string SortCode  { get; set; }
        [JsonProperty("routing_number", NullValueHandling = NullValueHandling.Ignore)]
        public string RoutingNumber { get; set; }
        [JsonProperty("bic", NullValueHandling = NullValueHandling.Ignore)]
        public string Bic { get; set; }
        [JsonProperty("clabe", NullValueHandling = NullValueHandling.Ignore)]
        public string Clabe { get; set; }
        [JsonProperty("ifsc", NullValueHandling = NullValueHandling.Ignore)]
        public string Ifsc {  get; set; }
        [JsonProperty("bsb_code", NullValueHandling = NullValueHandling.Ignore)]
        public string BsbCode { get; set; }
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public CounterpartyAddress Address { get; set; }


        public CreateCounterpartyReq(string companyName = null, 
            string profileType = null, 
            string name = null, 
            IndividualName individualName = null, 
            string bankCountry = null,
            string currency = null,
            string revtag = null,
            string accountNo = null,
            string iban = null,
            string sortCode = null,
            string routingNumber = null,
            string bic = null,
            string clabe = null,
            string ifsc = null,
            string bsbCode = null,
            CounterpartyAddress address = null)
        {
            CompanyName = companyName;
            ProfileType = profileType;
            Name = name;
            IndividualName = individualName;
            BankCountry = bankCountry;
            Currency = currency;
            Revtag = revtag;
            AccountNo = accountNo;
            Iban = iban;
            SortCode = sortCode;
            RoutingNumber = routingNumber;
            Bic = bic;
            Clabe = clabe;
            Ifsc = ifsc;
            BsbCode = bsbCode;
            Address = address;

        }
    }
}
