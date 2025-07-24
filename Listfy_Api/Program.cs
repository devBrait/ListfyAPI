using System.Text;
using DotNetEnv;
using FluentValidation;
using Listfy_Application.Services;
using Listfy_Domain.Interfaces;
using Listfy_Domain.Validators;
using Listfy_Infrastructure.Auth;
using Listfy_Infrastructure.Context;
using Listfy_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
    
Env.Load(".env.development");

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables(); 

var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
var port = Environment.GetEnvironmentVariable("POSTGRES_PORT");
var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
var db = Environment.GetEnvironmentVariable("POSTGRES_DB");

var connectionString = $"Host={host};Port={port};Username={user};Password={password};Database={db}";

builder.Services.AddDbContext<DataContext>(x => 
    x.UseNpgsql(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SecurityService>();
builder.Services.AddValidatorsFromAssemblyContaining<UserDTOValidator>(); 


var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
var key = Environment.GetEnvironmentVariable("JWT_KEY") ?? String.Empty;

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
