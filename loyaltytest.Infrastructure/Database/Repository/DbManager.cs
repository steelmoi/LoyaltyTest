using loyaltytest.Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Infrastructure.Database.Repository
{
    public class DbManager<TEntity> : IDbManager<TEntity> where TEntity : class
    {
        protected readonly LoyaltyDBContext dbContext;
        public DbManager(LoyaltyDBContext dbContext) => this.dbContext = dbContext;

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity); ;
            dbContext.SaveChanges();
        }

        public TEntity AddEntity(TEntity entity)
        {
            var ent = dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
            return ent.Entity;
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
            dbContext.SaveChanges();
        }

    }
}
