using System;
using System.ComponentModel.DataAnnotations;

namespace RevolutAPI.Models.BusinessApi.Payment
{
    public class SchedulePaymentReq
    {
        public class ReceiverData
        {
            [Required(AllowEmptyStrings = false)]
            public string CounterpartyId { get; set; }
            [Required(AllowEmptyStrings = false)]
            public string AccountId { get; set; }
        }

        [Required(AllowEmptyStrings = false)]
        public string RequestId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string AccountId { get; set; }
        [Required]
        public CreatePaymentReq.ReceiverData Receiver { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Currency { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Reference { get; set; }
        public DateTime ScheduleFor { get; set; }
    }
}
