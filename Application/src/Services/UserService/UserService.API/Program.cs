using System.Text;
using UserService.Application;
using UserService.Infrastructure;
using JWTAuthenticator;
using UserManagement.API.Services;
using BuildingBlocks.Exceptions.Handler;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwtAuthentication();

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);    

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);   
});


builder.Services.AddTransient<JwtTokenService>();
builder.Services.AddTransient<UserServices>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.Use(async (context, next) =>
//{
//    var initialBody = context.Request.Body;

//    using (var bodyReader = new StreamReader(context.Request.Body))
//    {
//        string body = await bodyReader.ReadToEndAsync();
//        Console.WriteLine(body);
//        context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
//        await next.Invoke();
//        context.Request.Body = initialBody;
//    }
//});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
