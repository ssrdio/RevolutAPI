using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.WebHookV2.WebHookEvents
{
    public class TransactionCreated : IWebhookPayload
    {
        public string Event { get; set; }
        public string Timestamp { get; set; }
        public TransactionCreatedData Data { get; set; }

    }
    public class TransactionCreatedData 
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string RequestId { get; set; }
        public string ReasonCode {  get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string CompletedAt { get; set; }
        public string ScheduledFor { get; set; }
        public string Reference { get; set; }
        public string RelatedTransactionId { get; set; }
        public List<Legs> Legs { get; set; }
        
    }
    public class Legs
    {
        public string LegId { get; set; }
        public string AccountId { get; set; }
        public  CounterParty CounterParty { get; set;}
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public string Currency { get; set; }
        public string BillCurrency { get; set; }
        public string Description { get ; set; }
        public decimal Balance { get; set; }
        
    }
    public class CounterParty
    {
        public string Id { get; set; }
        public string AccountID { get; set; }
        public string AccountType { get; set; }
    }
}
