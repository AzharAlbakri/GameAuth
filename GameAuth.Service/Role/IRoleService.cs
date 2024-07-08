using GameAuth.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAuth.Service.Role
{
    public interface IRoleService
    {
        void Add(AddRoleDto addRoleDto);
        RoleDto getById(Guid id);
    }
}
