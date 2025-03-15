using Finanzauto.Application.Interfaces;
using Finanzauto.Application.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Finanzauto.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IStudentApplication, StudentApplication>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IAuthApplication, AuthApplication>();

            return services;
        }
    }
}
