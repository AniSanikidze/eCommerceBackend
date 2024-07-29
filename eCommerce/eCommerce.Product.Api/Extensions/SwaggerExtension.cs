using Microsoft.OpenApi.Models;
using System.Reflection;

namespace eCommerce.Product.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "eCommerce.ProductAPI", 
                    Version = "v1", 
                    Description = "Product and product categories management system" });
                opt.UseAllOfToExtendReferenceSchemas();
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new[] { "roles" }
                }
            });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine($"{AppContext.BaseDirectory}", xmlFile);

                opt.IncludeXmlComments(xmlPath);
            });
            return services;
        }
    }
}