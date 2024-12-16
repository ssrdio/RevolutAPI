using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PaymentDrafts
{
    public class CreatePaymentDraftResp
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
