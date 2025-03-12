using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using loyaltytest.Infrastructure.Database.Interfaces;

namespace loyaltytest.Infrastructure.Database.Repository
{
    public class CustomerRepository: DbManager<Customer>, ICustomerRepository
    {
        public CustomerRepository(LoyaltyDBContext loyaltyDBContext) : base(loyaltyDBContext)
        {
        }

        public Customer AddCustomer(CustomerRequest customer)
        {
            var newCustomer = new Customer()
            {
                CustomerId = 0,
                CreatedDate = DateTime.Now,
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName,
                CustomerName = customer.CustomerName,
                Status = customer.Status,
                UpdatedDate = DateTime.Now
            };
            return this.AddEntity(newCustomer);
        }

        public Customer Get(long CustomerId)
        {
            return
                this.dbContext
                .Customer
                .Where(C => C.CustomerId == CustomerId)
                .FirstOrDefault();
        }

        public List<Customer> GetAll()
        {
            return
                this.dbContext
                .Customer
                .Where(C => C.Status == 1)
                .ToList();
        }

        public Customer UpdateCustomer(CustomerRequest customer)
        {
            var customerUpdate = this.dbContext.Customer
                                .Where(C => C.CustomerId == customer.CustomerId)
                                .FirstOrDefault();


            customerUpdate.CustomerFirstName = customer.CustomerFirstName;
            customerUpdate.CustomerLastName = customer.CustomerLastName;
            customerUpdate.CustomerName = customer.CustomerName;
            customerUpdate.UpdatedDate = DateTime.Now;
            customerUpdate.Status = customer.Status;

            this.Update(customerUpdate);

            return customerUpdate;
        }
    }
}
