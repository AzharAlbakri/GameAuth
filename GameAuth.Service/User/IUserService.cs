using GameAuth.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAuth.Service.User
{
    public interface IUserService
    {
        void Add(AddUserDto addUserDto);
        UserDto getById(Guid id);
        UserDto getByEmail(string email, string password);
    }
}
