using GameAuth.Entities.Interface.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameAuth.Infrastructure.Repository.User
{
    public class UserRepository : Repository<Entities.Models.User>,IUserRepository
    {
    }
}
