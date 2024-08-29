using System.ComponentModel.DataAnnotations;

namespace RevolutAPI.Models.BusinessApi.Payment
{
    public class TransferReq
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(30)]
        public string RequestId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string SourceAccountId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string TargetAccountId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Currency { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}