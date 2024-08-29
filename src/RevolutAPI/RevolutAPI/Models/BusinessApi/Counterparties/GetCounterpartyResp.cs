using System;
using System.Collections.Generic;

namespace RevolutAPI.Models.BusinessApi.Counterparties
{
    public class GetCounterpartyResp
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ProfileType { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<CounterpartyAccountResp> Accounts { get; set; }
    }
}
