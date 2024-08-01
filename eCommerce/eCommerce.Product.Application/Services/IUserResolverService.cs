using System.Security.Claims;

namespace eCommerce.Product.Application.Services
{
    public interface IUserResolverService
    {
        ClaimsPrincipal? User { get; }
        Guid? UserId { get; }
        bool IsAdmin();
    }
}
