using Newtonsoft.Json;
using RevolutAPI.Models.BusinessApi.PaymentDrafts.Objects;
using RevolutAPI.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.Models.BusinessApi.PaymentDrafts
{
    public class CreatePaymentDraftReq
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("schedule_for")]
        public DateTime? ScheduleFor { get; set; }
        [JsonProperty("payments")]
        public List<CreatePaymentDraftPayments> Payments { get; set; }

        public CreatePaymentDraftReq(List<CreatePaymentDraftPayments> payments, string title= null, DateTime? scheduleFor= null)
        {
            Title = title;
            ScheduleFor = scheduleFor;
            Payments = payments;
        }
    }
  

    
  

}
