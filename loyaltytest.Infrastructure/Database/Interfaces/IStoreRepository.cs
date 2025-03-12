using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;

namespace loyaltytest.Infrastructure.Database.Interfaces
{
    public interface IStoreRepository : IDbManager<Store>
    {
        IQueryable<Store> GetAll();
        Store Get(long StoreId);
        Store AddStore(StoreRequest store);
        Store UpdateStore(StoreRequest store);
        Store AddProduct2Store(ProductStore productStore);
    }
}
