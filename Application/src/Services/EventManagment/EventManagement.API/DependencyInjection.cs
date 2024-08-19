using BuildingBlocks.Exceptions.Handler;
using EventManagement.Infrastructure.Data;
using System.Reflection;

namespace UserService.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddExceptionHandler<CustomExceptionHandler>();

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddTransient<DbContextClass>();

            return services;

        }
    }
}