using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Enterprise.Applications.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            });

            return services;
        }
    }
}
