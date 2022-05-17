using RevolutAPI.Models.BusinessApi.Account;
using System;
using System.Collections.Generic;

namespace RevolutAPI.Models.BusinessApi.Payment
{

    public class TransactionResp
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string RequestId { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public string Reference { get; set; }
        public List<LegData> Legs { get; set; }

    }
}