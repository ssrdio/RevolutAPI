namespace RevolutAPI.Models.BusinessApi.Counterparties
{
    public class AddNonRevolutCounterpartyReq
    {
        public class AddressData
        {
            public string StreetLine1 { get; set; }
            public string StreetLine2 { get; set; }
            public string Region { get; set; }
            public string Postcode { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
        }

        public class IndividualNameData
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public string CompanyName { get; set; }
        public IndividualNameData IndividualName { get; set; }
        public string BankCountry { get; set; }
        public string Currency { get; set; }
        public string AccountNo { get; set; }
        public string SortCode { get; set; }
        public string RoutingNumber { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressData Address { get; set; }


    }
}
