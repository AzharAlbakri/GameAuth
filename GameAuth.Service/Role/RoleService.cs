using GameAuth.Entities.Interface.Role;
using GameAuth.Entities.Interface.User;
using GameAuth.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAuth.Service.Role
{
    public class RoleService(IRoleRepository roleRepository) : IRoleService
    {

        public void Add(AddRoleDto addRoleDto)
        {
            roleRepository.Add(new Entities.Models.Role(Guid.NewGuid(), addRoleDto.Name));
        }
        public RoleDto getById(Guid id)
        {
            var role = roleRepository.GetById(id);

            return new RoleDto(role.Id, role.Name);
        }

    }
}
