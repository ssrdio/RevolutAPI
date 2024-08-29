using System.ComponentModel.DataAnnotations;

namespace RevolutAPI.Models.BusinessApi.Payment
{
    public class CancelPaymentReq
    {
        [Required(AllowEmptyStrings = false)]
        public string Id { get; set; }
    }
}