using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ShreenexTech.API.Application.Features.Portfolios.Command;
using ShreenexTech.API.Application.Features.Services.Command;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Infrastructure.Data;
using ShreenexTech.API.Infrastructure.Repositories;
using ShreenexTech.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ? ADD SERVICES BEFORE BUILD
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreatePortfolioCommand).Assembly);
//builder.Services.AddMediatR(typeof(CreateServiceCommand).Assembly);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// CORS (?? MUST be here)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Swagger (optional)
builder.Services.AddEndpointsApiExplorer();



// ? BUILD APP (after all services)
var app = builder.Build();


// ? USE CORS AFTER BUILD
app.UseCors("AllowAll");
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();