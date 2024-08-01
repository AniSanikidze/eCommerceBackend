namespace eCommerce.ApiGateway.Options
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
