using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? BusinessName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public List<CustomersPaymentMethodsEntity> PaymentMethods { get; set; }
    }
}

