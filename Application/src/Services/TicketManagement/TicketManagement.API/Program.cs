using BuildingBlocks.Exceptions.Handler;
using TicketManagement.API.Services;
using TicketsManagement.Application;
using TicketsManagement.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);
//.AddApiServices(builder.Configuration);


builder.Services.AddTransient<IBookingPaymentProcessingClient, BookingPaymentProcessingClient>();



var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
   // config.RegisterServicesFromAssembly(typeof(UserService.Application.Commands.RegisterUserCommandHandler).Assembly);
});

builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
