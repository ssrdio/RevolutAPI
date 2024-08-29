using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities
{
    public class CustomersPaymentMethodsEntity
    {
        [Key]
        public int Id { get; set; }
        public string PaymentMethodId { get; set; }
        public string Type { get; set; }
        public string Last4 { get; set; }
        public string SavedFor { get; set; }
        public string CustomerId { get; set; }
        [JsonIgnore]
        public CustomerEntity Customer { get; set; }
    }
}
