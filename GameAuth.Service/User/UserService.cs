using GameAuth.Entities.Interface.User;
using GameAuth.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAuth.Service.User
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public void Add(AddUserDto addUserDto)
        {
            var user = new Entities.Models.User(Guid.NewGuid(), addUserDto.UserName, addUserDto.Email, addUserDto.Password);

            if (addUserDto.Roles?.Any() is true)
            {
                var roles = addUserDto.Roles.Select(r=>new Entities.Models.Role(Guid.NewGuid(), r.Name)).ToList();
                user.AssignRole(roles);
            }

            userRepository.Add(user);
        }

        public UserDto getByEmail(string email, string password)
        {
            var user = userRepository.Find(e => e.Email == email && e.Password == password).FirstOrDefault();

            if(user is null)
            {
                return null;
            }
            var roles = user.Roles.Select(e => new RoleDto(e.Id, e.Name)).ToList();
            return new UserDto(user.Id, user.Username, user.Email, roles);
        }

        public UserDto getById(Guid id)
        {
            var user = userRepository.GetById(id);
            var roles = user.Roles.Select(e => new RoleDto(e.Id, e.Name)).ToList();
            return new UserDto(user.Id, user.Username, user.Email, roles);
        }

    }
}
