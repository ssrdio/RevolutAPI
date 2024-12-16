using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders.Objects
{
    public class NameAmount
    {
        public string Name { get; set; }
        public long Amount { get; set; }
        public NameAmount(string name, long amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
