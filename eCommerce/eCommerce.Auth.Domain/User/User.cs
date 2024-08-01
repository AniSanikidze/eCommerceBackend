using Microsoft.AspNetCore.Identity;

namespace eCommerce.Auth.Domain.User
{
    public class User : IdentityUser<Guid>
    {
        public string PersonalNumber { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
