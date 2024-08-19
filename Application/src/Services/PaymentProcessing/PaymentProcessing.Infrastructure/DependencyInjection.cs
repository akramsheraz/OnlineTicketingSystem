using EventManagement.Infrastructure.Respositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentProcessing.Domain;




namespace PaymentProcessing.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }    
}
