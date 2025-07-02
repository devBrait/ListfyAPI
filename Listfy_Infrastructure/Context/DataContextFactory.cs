using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace Listfy_Infrastructure.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
            if (File.Exists(envPath))
            {
                Env.Load(envPath);
            }

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            
            var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
            var username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "postgres123";
            var database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "listfy_db";
            
            var connectionString = $"Host={host};Port={port};Username={username};Password={password};Database={database}";
            
            optionsBuilder.UseNpgsql(connectionString);
            
            return new DataContext(optionsBuilder.Options);
        }
    }
}