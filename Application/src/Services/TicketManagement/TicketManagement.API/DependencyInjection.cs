using BuildingBlocks.Exceptions.Handler;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TicketManagement.API.Services;
using TicketsManagement.Infrastructure.Data;

namespace TicketManagement.API
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
            services.AddTransient<IBookingPaymentProcessingClient, BookingPaymentProcessingClient>();
            return services;

        }
    }
}