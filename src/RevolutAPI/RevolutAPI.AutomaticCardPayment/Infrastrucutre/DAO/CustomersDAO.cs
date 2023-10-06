using Microsoft.EntityFrameworkCore;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Database;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities;

namespace RevolutAPI.AutomaticCardPayment.Infrastrucutre.DAO
{
    public class CustomersDAO
    {
        private readonly CustomersDBContext _dbContext;

        public CustomersDAO(CustomersDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerEntity?> Get(string id)
        {
            return await _dbContext.Customers
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> Add(CustomerEntity model)
        {
            _dbContext.Customers.Add(model);
            int changes = await _dbContext.SaveChangesAsync();
            if(changes == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> AddRange(List<CustomerEntity> model)
        {
            _dbContext.Customers.AddRange(model);
            int changes = await _dbContext.SaveChangesAsync();
            if (changes != model.Count)
            {
                return false;
            }

            return true;
        }

        public async Task<List<CustomerEntity>> GetAll()
        {
            return await _dbContext.Customers
                .ToListAsync();
        }

        public async Task<List<CustomerEntity>> GetAllIncluded()
        {
            return await _dbContext.Customers
                .Include(x => x.PaymentMethods)
                .ToListAsync();
        }

        public async Task<bool> DeleteCustomerWithCustomerId(string customerId)
        {
            CustomerEntity? customer = _dbContext.Customers
                .Where(x=>x.Id == customerId)
                .FirstOrDefault();

            if(customer == null)
            {
                return false;
            }

            _dbContext.Customers.Remove(customer);

            int changes = await _dbContext.SaveChangesAsync();
            if(changes <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
