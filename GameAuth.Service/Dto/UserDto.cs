using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAuth.Service.Dto
{
    public record UserDto(Guid Id, string UserName, string Email,List<RoleDto> Roles);
}
