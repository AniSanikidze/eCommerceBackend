using eCommerce.Auth.Application.Common.Interfaces;
using eCommerce.Auth.Infrastructure.Options;
using eCommerce.Auth.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Auth.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Key));
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            return services;
        }
    }
}
