using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutAPI.Models.MerchantApi.Customers
{
    public class UpdatePaymentMethod
    {
        [JsonProperty("saved_for")]
        public string SavedFor { get; set; }
        public UpdatePaymentMethod(string savedFor)
        {
            SavedFor = savedFor;
        }
    }
}
