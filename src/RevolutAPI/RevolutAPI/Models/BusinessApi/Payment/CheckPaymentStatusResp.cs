using System;
using System.Collections.Generic;

namespace RevolutAPI.Models.BusinessApi.Payment
{
    public class CheckPaymentStatusResp
    {
        public class CounterPartyData
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public string AccountId { get; set; }
        }

        public class CardData
        {
            public string CardNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class MerchantData
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string CategoryCode { get; set; }
            public string Country { get; set; }
        }

        public class LegData
        {
            public string LegId { get; set; }
            public string AccountId { get; set; }
            public string Description { get; set; }
            public CounterPartyData CounterParty { get; set; }
            public double Amount { get; set; }
            public string Currency { get; set; }
            public double BillAmount { get; set; }
            public string BillCurrency { get; set; }
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public string RequestId { get; set; }
        public string State { get; set; } // TODO: try parse as enum 
        public string ReasonCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public string ScheduledFor { get; set; } // optional
        public string Reference { get; set; }
        public MerchantData Merchant { get; set; } // optional
        public CardData Card { get; set; } // optional
        public List<LegData> Legs { get; set; }
    }
}