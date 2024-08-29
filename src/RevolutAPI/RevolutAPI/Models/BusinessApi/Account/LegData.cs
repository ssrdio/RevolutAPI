namespace RevolutAPI.Models.BusinessApi.Account
{
    public class LegData
    {
        public string leg_id { get; set; }
        public string account_id { get; set; }
        public CounterPartyData counterparty { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
    }
}
