using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities
{
    public class AutomaticChargeEntity : ICreatedAt
    {
        [Key]
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string SavedMethodId { get; set; }
        public string State { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
