using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Entities;
using RevolutAPI.AutomaticCardPayment.Infrastrucutre.Models.Interfaces;

namespace RevolutAPI.AutomaticCardPayment.Infrastrucutre.Database
{
    public class CustomersDBContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomersPaymentMethodsEntity> CustomersPaymentMethods { get; set; }
        public DbSet<AutomaticChargeEntity> AutomaticCharges { get; set; }

        public string DbPath { get; }

        public CustomersDBContext() 
        {
            DbPath = "customers.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.EnableDetailedErrors(true);
            options.UseSqlite($"Data Source={DbPath}");
        }

        public override int SaveChanges()
        {
            return SaveChanges(acceptAllChangesOnSuccess: true);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ProcessEnities();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ProcessEnities();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ProcessEnities()
        {
            List<EntityEntry> entities = ChangeTracker
                .Entries()
                .ToList();

            DateTimeOffset timestamp = DateTimeOffset.UtcNow;

            foreach (EntityEntry entity in entities)
            {
                if (entity.State == EntityState.Added && entity.Entity is ICreatedAt createdTimestampEntity)
                {
                    createdTimestampEntity.CreatedAt = timestamp;
                }
            }
        }

    }
}
