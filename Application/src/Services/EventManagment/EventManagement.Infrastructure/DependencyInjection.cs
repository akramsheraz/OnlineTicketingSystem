using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using EventManagement.Infrastructure.Respositories;
using EventManagement.Infrastructure.Data;



namespace UserService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddDbContext<DbContextClass>();

            return services;
        }
    }    
}
