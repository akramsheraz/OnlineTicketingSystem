using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketsManagement.Infrastructure.Data;
using TicketsManagement.Infrastructure.Respositories;



namespace TicketsManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
                    

            services.AddScoped<ITicketBookingRepository, TicketBookingRepository>();
            services.AddDbContext<DbContextClass>();

            return services;
        }
    }    
}
