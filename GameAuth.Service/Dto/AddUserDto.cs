using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAuth.Service.Dto
{
    public record AddUserDto( string UserName, string Email,string Password,List<RoleDto>? Roles = null);

}
