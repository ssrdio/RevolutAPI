using Microsoft.EntityFrameworkCore;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Database;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities;

namespace RevolutAPI.AutomaticCardPayment.Infrastrucutre.DAO
{
    public class CustomersPaymentMethodsDAO
    {
        private readonly CustomersDBContext _dbContext;

        public CustomersPaymentMethodsDAO(CustomersDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CustomersPaymentMethodsEntity>> Get(string customerId)
        {
            return await _dbContext.CustomersPaymentMethods
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<bool> Add(List<CustomersPaymentMethodsEntity> model)
        {
            _dbContext.CustomersPaymentMethods.AddRange(model);

            int changes = await _dbContext.SaveChangesAsync();
            if(changes != model.Count())
            {
                return false;
            }

            return true;
        }
    }
}
