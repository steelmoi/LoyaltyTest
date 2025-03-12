using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;

namespace loyaltytest.Infrastructure.Database.Interfaces
{
    public interface ICustomerRepository: IDbManager<Customer>
    {
        List<Customer> GetAll();
        Customer Get(long CustomerId);
        Customer AddCustomer(CustomerRequest customer);
        Customer UpdateCustomer(CustomerRequest customer);
    }
}
