using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Infrastructure.Database.Interfaces
{
    public interface IDbManager<TEntity> where TEntity : class
    {
        TEntity AddEntity(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
