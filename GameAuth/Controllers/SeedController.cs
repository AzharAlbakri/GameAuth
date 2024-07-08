using GameAuth.Service.Dto;
using GameAuth.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameAuth.Controllers
{
    [Route("api/[controller]")]
    public class SeedController(IUserService userService) : BaseController
    {
       

        // POST api/<SeedController>
        [HttpPost]
        [AllowAnonymous]

        public void Post()
        {
            AddUserDto userDto = new("Azhar", "a.albakri@Gmail.com", "P@ssw0rd", new List<RoleDto>
            {
                new RoleDto(Guid.NewGuid(),"superadmin")
            });
            userService.Add(userDto);
        }

       
    }
}
