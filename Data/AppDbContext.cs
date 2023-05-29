using CompanyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<department> departments { get; set; }
        public DbSet<task> tasks { get; set; }
        public DbSet<comment> comments { get; set; }

    }
}
