using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Database;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities;

namespace RevolutAPI.AutomaticCardPayment.Infrastrucutre.DAO
{
    public class AutomaticChargeDAO
    {
        private readonly CustomersDBContext _dbContext;

        public AutomaticChargeDAO(CustomersDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(AutomaticChargeEntity model)
        {
            _dbContext.AutomaticCharges.Add(model);

            int changes = await _dbContext.SaveChangesAsync();
            if(changes <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
