namespace RevolutAPI.Models.BusinessApi.Counterparties
{
    public class CounterpartyAccountResp
    {
        public string Id { get; set; }
        public string Currency { get; set; }
        public string Type { get; set; }
        public string AccountNo { get; set; }
        public string Iban { get; set; }
        public string SortCode { get; set; }
        public string RoutingNumber { get; set; }
        public string Bic { get; set; }
        public string RecipientCharges { get; set; }
    }
}
