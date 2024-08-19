using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserManagement.Infrastructure.Data;
using UserService.Infrastructure.Repositories;



namespace UserService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped<IUserRepository, UserRespository>();            
            services.AddDbContext<UserDBContext>();

            return services;
        }
    }    
}
