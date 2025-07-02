using Listfy_Domain.Entities;
using Listfy_Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Listfy_Infrastructure.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}