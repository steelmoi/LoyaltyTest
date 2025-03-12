using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Infrastructure.Database.Interfaces
{
    public interface IAddressStoreRepository: IDbManager<AddressStore>
    {
        IQueryable<AddressStore> GetAll();
        AddressStore Get(long AddressId);
        AddressStore AddAddress(AddressRequest address);
        AddressStore UpdateAddress(AddressRequest address);
    }
}
