namespace RevolutAPI.AutomaticCardPayment.Features.AutomaticPayment.Models
{
    public class CreateCustomerAndOrder
    {
        public string? FullName { get; set; }
        public string? BusinessName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public double Amount { get; set; }
        public string? Description { get; set; }
        public string? MerchantCustomerExtRef { get; set; }
        public string? MerchantOrderExtRef { get; set; }
    }
}
