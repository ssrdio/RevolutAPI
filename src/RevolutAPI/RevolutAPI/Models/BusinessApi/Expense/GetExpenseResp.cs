using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Expense
{
    public class GetExpenseResp
    {
        public string Id { get; set; }
        public string State { get; set; }
        public string TranscationType { get; set; }
        public string Description {get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public string Payer { get; set; }
        public string Merchant { get; set; }
        public string TransactionId { get; set; }
        public DateTime ExpenseDate { get; set; }
        //labels =object...

        public ExpenseSplits Splits { get; set; }
        public List<string> ReceiptIds { get; set; }
        public ExpenseSplitAmount SpentAmount { get; set; }


    }
}
