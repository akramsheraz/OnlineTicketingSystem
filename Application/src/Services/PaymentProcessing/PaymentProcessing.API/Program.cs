using PaymentProcessing.Application;
using PaymentProcessing.Grpc.Services;
using PaymentProcessing.Infrastructure;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddGrpc();
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services
//    .AddApplicationServices(builder.Configuration)
//    .AddInfrastructureServices(builder.Configuration);
////.AddApiServices(builder.Configuration);

//var assembly = typeof(Program).Assembly;
//builder.Services.AddMediatR(config =>
//{
//    config.RegisterServicesFromAssembly(assembly);
//   // config.RegisterServicesFromAssembly(typeof(UserService.Application.Commands.RegisterUserCommandHandler).Assembly);
//});


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.MapGrpcService<PaymentService>();

//app.UseAuthorization();

////app.MapControllers();

//app.Run();



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<PaymentService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
