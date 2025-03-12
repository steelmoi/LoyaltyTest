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
    public class UserRepository : DbManager<Users>, IUserRepository
    {
        public UserRepository(LoyaltyDBContext dbContext) : base(dbContext)
        {
        }

        public Users Login(UserRequest userRequest)
        {
            return 
            this.dbContext.Users
                .Where(U => U.Password == userRequest.Password && U.UserCode == userRequest.UserCode)
                .FirstOrDefault();
        }
    }
}
