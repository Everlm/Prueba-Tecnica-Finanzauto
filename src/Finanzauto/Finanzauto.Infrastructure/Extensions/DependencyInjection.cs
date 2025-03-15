using Finanzauto.Infrastructure.Persistences.Contexts;
using Finanzauto.Infrastructure.Persistences.Interfaces;
using Finanzauto.Infrastructure.Persistences.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finanzauto.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(FinanzautoContext).Assembly.FullName;

            services.AddDbContext<FinanzautoContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("Connection"),
                        b => b.MigrationsAssembly(assembly)), ServiceLifetime.Scoped);

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<FinanzautoContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
