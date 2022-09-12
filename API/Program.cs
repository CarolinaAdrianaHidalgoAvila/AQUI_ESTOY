
using AQUI_ESTOY.Data;
using AQUI_ESTOY.Data.Repository;
using AQUI_ESTOY.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AquiEstoyDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AquiEstoyDB"));
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();
app.Run();


