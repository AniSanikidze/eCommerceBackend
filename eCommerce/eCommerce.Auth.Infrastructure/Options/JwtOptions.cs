using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Auth.Infrastructure.Options
{
    public class JwtOptions
    {
        public const string Key = "Jwt";
        public required string SigningKey { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required string ExpirationInMinutes { get; set; }
    }
}
