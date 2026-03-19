using Microsoft.EntityFrameworkCore;
using ShreenexTech.API.Data;

var builder = WebApplication.CreateBuilder(args);

// ? ADD SERVICES BEFORE BUILD

// DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();

// CORS (?? MUST be here)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Swagger (optional)
builder.Services.AddEndpointsApiExplorer();



// ? BUILD APP (after all services)
var app = builder.Build();


// ? USE CORS AFTER BUILD
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();