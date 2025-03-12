using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;

namespace loyaltytest.Infrastructure.Database.Interfaces
{
    public interface IAdressRepository : IDbManager<Address>
    {
        IQueryable<Address> GetAll();
        Address Get(long AddressId);
        Address AddAddress(AddressRequest address);
        Address UpdateAddress(AddressRequest address);
    }
}
