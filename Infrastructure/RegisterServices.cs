using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Application.Interface;
using Infrastructure.Persistence;

namespace Infrastructure
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<Persistence.AppContext>(
                options => options.UseInMemoryDatabase("AppDb"));
            services.AddScoped<IAppContext>(provider => provider.GetRequiredService<Persistence.AppContext>());

            services.AddDbContext<POIContext>(
                option => option.UseInMemoryDatabase("POIDBb"));
            services.AddScoped<IPOIContext>(provider => provider.GetRequiredService<POIContext>());

            return services;
        }
    }
}
