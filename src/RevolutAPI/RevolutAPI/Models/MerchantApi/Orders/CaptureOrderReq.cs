using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.MerchantApi.Orders
{
    public class CaptureOrderReq
    {
        [JsonIgnore]
        public double Amount { get; set; }

        [JsonProperty("amount")]
        public long InternalAmount
        {
            get
            {
                return Convert.ToInt64(Amount * 100);
            }
        }
        public CaptureOrderReq(double amount)
        {
            Amount = amount;
        }
    }
}
