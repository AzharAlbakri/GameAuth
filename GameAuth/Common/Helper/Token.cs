using GameAuth.Entities;
using GameAuth.Service.Dto;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace GameAuth.Common.Helper
{
    public static class Token
    {
        public static string GenerateJwtToken(this UserDto user, JwtSettings appSettings)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Secret));

            var rights = new List<string> { "b_game" };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, string.Join(',', user.Roles.Select(e=>e.Name))),
                new Claim("rights", string.Join(',', rights))
            };


            var token = new JwtSecurityToken(
                appSettings.Issuer,
                appSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(appSettings.ExpiryMinutes),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
