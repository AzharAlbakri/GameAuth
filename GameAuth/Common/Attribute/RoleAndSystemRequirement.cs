using GameAuth.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace GameAuth.Common.Attribute
{
    public class RoleAndSystemRequirement : IAuthorizationRequirement
    {
        public List<string>? Roles { get; }
        public List<string>? Rights { get; }

        public RoleAndSystemRequirement(List<string>? roles, List<string>? rights)
        {
            Roles = roles;
            Rights = rights;
        }
    }

    public class RoleAndRightAuthorizationAttribute : TypeFilterAttribute
    {
        public RoleAndRightAuthorizationAttribute(string roles, string rights) : base(typeof(RoleAndSystemAuthorizationFilter))
        {
            var roleList = roles.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            var rightList = rights.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            Arguments = new object[] { new RoleAndSystemRequirement(roleList, rightList) };
        }

        private class RoleAndSystemAuthorizationFilter : IAsyncAuthorizationFilter
        {
            private readonly RoleAndSystemRequirement _requirement;

            public RoleAndSystemAuthorizationFilter(RoleAndSystemRequirement requirement)
            {
                _requirement = requirement ?? throw new ArgumentNullException(nameof(requirement));
            }

            public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
            {
                if (_requirement.Roles?.Any() is true)
                {
                    var roles = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value?.
                        Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (roles is null || roles?.Any(e => _requirement.Roles.Contains(e)) is false)
                    {
                        context.Result = new ForbidResult();
                    }
                }

                if (_requirement.Rights?.Any() is true)
                {
                    var rights = context.HttpContext.User.FindFirst("rights")?.Value?.
                       Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (rights is null ||  rights?.Any(e => _requirement.Rights.Contains(e)) is false)
                    {
                        context.Result = new ForbidResult();
                    }
                }

            }

        }


    }

}
