using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BasicMvcApp.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@admin.com"
                }
            );
        }

        // Define your DbSets (tables) here
        public DbSet<Employee> Employees { get; set; }
    }
}