using eCommerce.Auth.Domain.User;
using System.Security.Claims;

namespace eCommerce.Auth.Application.Common.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);

        Task<IEnumerable<Claim>?> GenerateClaims(User user);
    }
}
