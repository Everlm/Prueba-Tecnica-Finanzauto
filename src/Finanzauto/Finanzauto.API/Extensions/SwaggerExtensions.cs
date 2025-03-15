using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Finanzauto.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "Finanzauto",
                Version = "v1",
                Description = "Finanzauto Backend",
                TermsOfService = new Uri("https://opensource.org/licenses/MIT"),
                Contact = new OpenApiContact
                {
                    Name = "EverDev",
                    Email = "Everlm17@gmail.com",
                    Url = new Uri("https://www.linkedin.com/in/deveverlm/")
                },
                License = new OpenApiLicense
                {
                    Name = "License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }

            };

            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "JWT Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement

                {
                    {securityScheme, new string[] {} }
                });
            });

            return services;
        }
    }
}
