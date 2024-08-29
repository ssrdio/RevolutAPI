using System;

namespace RevolutAPI.Models.BusinessApi.Payment
{
    public class CreatePaymentResp
    {
        public string Id { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}