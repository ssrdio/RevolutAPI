using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.Expense
{
    public class ExpenseSplits
    {
        public ExpenseSplitAmount Amount { get; set; }
        public ExpenseSplitCategory Category { get; set; }
        public ExpenseSplitTaxRate TaxRate { get; set; }

    }
}
