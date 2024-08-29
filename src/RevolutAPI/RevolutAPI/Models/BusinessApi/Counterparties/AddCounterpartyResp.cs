using System;
using System.Collections.Generic;

namespace RevolutAPI.Models.BusinessApi.Counterparties
{
    public class AddCounterpartyResp
    {
        public class AddCounterpartyAccountResp
        {
            public string ID { get; set; }
            public string Currency { get; set; }
            public string Type { get; set; }
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ProfileType { get; set; }
        public string BankCountry { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<AddCounterpartyAccountResp> Accounts { get; set; }
    }
}
