using eCommerce.Common;
using eCommerce.Product.Application.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace eCommerce.Product.Infrastructure.Services
{
    public class UserResolverService(IHttpContextAccessor contextAccessor) : IUserResolverService
    {
        public ClaimsPrincipal? User => contextAccessor.HttpContext?.User;

        public Guid? UserId => GetUserIdClaim() != null ? Guid.Parse(GetUserIdClaim()!) : null;

        public bool IsAdmin() => User.IsInRole(Roles.Admin);

        private string? GetUserIdClaim()
        {
            return User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
