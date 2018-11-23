using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.Counterparties
{
    public class AddNonRevolutCounterpartyResp
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<CounterpartyAccountResp> Accounts { get; set; }
    }
}
