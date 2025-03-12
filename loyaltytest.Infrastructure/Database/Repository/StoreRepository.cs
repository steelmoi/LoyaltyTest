using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using loyaltytest.Infrastructure.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace loyaltytest.Infrastructure.Database.Repository
{
    public class StoreRepository : DbManager<Store>, IStoreRepository
    {
        public StoreRepository(LoyaltyDBContext loyaltyDBContext) : base(loyaltyDBContext) { 
        }

        public Store AddProduct2Store(ProductStore productStore)
        {
            var store = this.dbContext.Store.Where(S => S.StoreId == productStore.StoresStoreId).FirstOrDefault();

            var products = this.dbContext.Product.Where(P => P.ProductId == productStore.ProductsProductId).FirstOrDefault();

            if(store.Products == null)
                store.Products = new List<Product>();

            store.Products.Add(products);
            this.dbContext.SaveChanges();

            return store;
        }

        public Store AddStore(StoreRequest store)
        {
            var newStore = new Store()
            {
                CreatedDate = DateTime.Now,
                Status = store.Status,
                StoreId = 0,
                StoreName = store.StoreName,
                StoreCode = store.StoreCode,
                UpdatedDate = DateTime.Now
            };

            return this.AddEntity(newStore);
        }

        public Store Get(long StoreId)
        {
            return this.dbContext
                    .Store
                    .Where(S => S.StoreId == StoreId)
                    .Include(X => X.Products)
                    .FirstOrDefault();
        }

        public IQueryable<Store> GetAll()
        {
            return this.dbContext
            .Store
                    .Where(S => S.Status == 1);
        }

        public Store UpdateStore(StoreRequest store)
        {
            var storeDB = this.dbContext.Store
                            .Where(S => S.StoreId  == store.StoreId)
                            .FirstOrDefault();

            storeDB.StoreName = store.StoreName;
            storeDB.StoreCode = store.StoreCode;
            storeDB.UpdatedDate = DateTime.Now;
            storeDB.Status = store.Status;

            this.Update(storeDB);
            return storeDB;
        }
    }
}
