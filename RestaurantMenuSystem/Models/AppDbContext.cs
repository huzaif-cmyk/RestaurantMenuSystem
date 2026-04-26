using Microsoft.EntityFrameworkCore;

namespace RestaurantSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // mapping to the exact table name in your database
            modelBuilder.Entity<MenuItem>().ToTable("menuitems");
        }
    }
}