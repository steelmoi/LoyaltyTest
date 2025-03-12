using loyaltytest.Domain.dtos.Request;
using loyaltytest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyaltytest.Infrastructure.Database.Interfaces
{
    public interface IUserRepository: IDbManager<Users>
    {
        Users Login(UserRequest userRequest);
    }
}
