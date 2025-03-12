using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using loyaltytest.Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Infrastructure.Database.Repository
{
    public class AddressStoreRepository: DbManager<AddressStore>, IAddressStoreRepository
    {
        public AddressStoreRepository(LoyaltyDBContext loyaltyDBContext) : base(loyaltyDBContext)
        {

        }

        public AddressStore AddAddress(AddressRequest address)
        {
            var NewAddress = new AddressStore()
            {
                UpdatedDate = DateTime.Now,
                AddressStoreId = 0,
                City = address.City,
                Colony = address.Colony,
                CreatedDate = DateTime.Now,
                StoreId = (int)address.RelationShipId,
                NumExt = address.NumExt,
                NumInt = address.NumInt,
                PostalCode = address.PostalCode,
                State = address.State,
                Street = address.Street,
                Status = address.Status
            };
            return this.AddEntity(NewAddress);
        }

        public AddressStore Get(long AddressId)
        {
            return this.dbContext
            .AddressStore
            .Where(A => A.AddressStoreId == AddressId).FirstOrDefault();
        }

        public IQueryable<AddressStore> GetAll()
        {
            return this.dbContext
                        .AddressStore
                        .Where(A => A.Status == 1);
        }

        public AddressStore UpdateAddress(AddressRequest address)
        {
            var addressDB = this.dbContext.AddressStore
                            .Where(A => A.AddressStoreId != address.AddressId)
                            .FirstOrDefault();

            addressDB.Street = address.Street;
            addressDB.City = address.City;
            addressDB.Colony = address.Colony;
            addressDB.NumExt = address.NumExt;
            addressDB.NumInt = address.NumInt;
            addressDB.PostalCode = address.PostalCode;
            addressDB.State = address.State;
            addressDB.UpdatedDate = DateTime.Now;

            this.Update(addressDB);
            return addressDB;
        }
    }
}
