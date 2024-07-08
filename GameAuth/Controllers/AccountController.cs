using GameAuth.Common.Attribute;
using GameAuth.Common.Helper;
using GameAuth.Service.Dto;
using GameAuth.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameAuth.Controllers
{
    public class AccountController(IUserService userService, IConfiguration configuration) : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto model)
        {
            var user = userService.getByEmail(model.Email, model.Password);

            if (user == null)
            {
                return BadRequest();
            }

            var jwtSettings = configuration.GetSection("JWT").Get<JwtSettings>();
            var token = user.GenerateJwtToken(jwtSettings);
            return Ok(token);
        }


        [RoleAndRightAuthorization("VIP", "vip_character_personalize")]
        [HttpGet("test-authorization")]
        public IActionResult TestAuthorization()
        {
            return Ok();
        }
    }
}
