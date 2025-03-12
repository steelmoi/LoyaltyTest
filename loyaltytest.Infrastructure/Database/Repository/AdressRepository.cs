using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using loyaltytest.Infrastructure.Database.Interfaces;

namespace loyaltytest.Infrastructure.Database.Repository
{
    public class AdressRepository: DbManager<Address>, IAdressRepository
    {
        public AdressRepository(LoyaltyDBContext loyaltyDBContext) : base(loyaltyDBContext)
        {
        }

        public Address AddAddress(AddressRequest address)
        {
            var NewAddress  = new Address()
            {
                UpdatedDate = DateTime.Now,
                AddressId = 0,
                City = address.City,
                Colony = address.Colony,
                CreatedDate = DateTime.Now,
                CustomerId = (int)address.RelationShipId,
                NumExt = address.NumExt,
                NumInt = address.NumInt,
                PostalCode = address.PostalCode,
                State = address.State,
                Street = address.Street,
                Status = address.Status
            };
            return this.AddEntity(NewAddress);            
        }

        public Address Get(long AddressId)
        {
            return this.dbContext
                        .Address
                        .Where(A => A.AddressId == AddressId).FirstOrDefault();
        }

        public IQueryable<Address> GetAll()
        {
            return this.dbContext
                        .Address
                        .Where(A => A.Status == 1);
        }

        public Address UpdateAddress(AddressRequest address)
        {
            var addressDB = this.dbContext.Address
                            .Where(A=> A.AddressId != address.AddressId)
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
