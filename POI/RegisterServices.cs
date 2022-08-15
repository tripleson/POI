using Application.Interface;
using POI.Services;

namespace POI
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterWebUIServices(this IServiceCollection services)
        {
            services.AddSingleton<ICurrentUser, CurrentUser>();


            return services;
        }
    }
}
