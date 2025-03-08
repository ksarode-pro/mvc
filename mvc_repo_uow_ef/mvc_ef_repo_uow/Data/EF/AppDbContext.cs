using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Data.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        DbSet<Institute> Institutes { get; set; }
        DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institute>().HasData(new Institute[]
            {
                new Institute() {
                    Id = 10001,
                    Name = "Sardar Patel Institute",
                    City = "Mumbai",
                    Website = "spit.ac.in"
                },
                new Institute() {
                    Id = 10002,
                    Name = "Veer Jijabai Tech Institute",
                    City = "Mumbai",
                    Website = "www.vjti.in"
                },
                new Institute() {
                    Id = 10003,
                    Name = "Indian Institute of Tech",
                    City = "Kanpur",
                    Website = "iitk.gov.in"
                },
                new Institute() {
                    Id = 10004,
                    Name = "National Institute of Tech",
                    City = "Delhi",
                    Website = "nit.gov.in"
                }
            });
        }

    }
}
