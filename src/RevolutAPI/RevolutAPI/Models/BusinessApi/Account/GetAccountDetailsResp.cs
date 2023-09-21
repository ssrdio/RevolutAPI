using System.Collections.Generic;

namespace RevolutAPI.Models.BusinessApi.Account
{
    public class BeneficiaryAddress
    {
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
    }

    public class EstimatedTime
    {
        public string Unit { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public class GetAccountDetailsResp
    {
        public string Iban { get; set; }
        public string Bic { get; set; }
        public string UniqueReference { get; set; }
        public string AccountNo { get; set; }
        public string SortCode { get; set; }
        public string RoutingNumber { get; set; }
        public string Beneficiary { get; set; }
        public BeneficiaryAddress BeneficiaryAddress { get; set; }
        public string BankCountry { get; set; }
        public List<string> Schemas { get; set; } // TODO: try map to enum
        public bool Pooled { get; set; }
        public EstimatedTime EstimatedTime { get; set; }
    }
}