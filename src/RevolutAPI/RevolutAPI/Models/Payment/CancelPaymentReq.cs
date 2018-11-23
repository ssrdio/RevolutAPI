using System.ComponentModel.DataAnnotations;

namespace RevolutAPI.Models.Payment
{
    public class CancelPaymentReq
    {
        [Required(AllowEmptyStrings = false)]
        public string Id { get; set; }
    }
}