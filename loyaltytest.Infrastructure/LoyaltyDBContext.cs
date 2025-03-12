using loyaltytest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace loyaltytest.Infrastructure
{
    public class LoyaltyDBContext: DbContext
    {
        public LoyaltyDBContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Store> Store{ get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<AddressStore> AddressStore { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void ConfigureConventions(
                                ModelConfigurationBuilder configurationBuilder
            )
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 2);
        }

    }
}
