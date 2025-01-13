using DemoGenericRepositoryPattern.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace DemoGenericRepositoryPattern.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(e => e.Id)
                .HasConversion(
                    // Convert string to Guid when saving to the database
                    v => Guid.Parse(v),
                    // Convert Guid to string when reading from the database
                    v => v.ToString()
                );
            modelBuilder.Entity<Category>()
                .Property(e => e.Id)
                .HasConversion(
                    // Convert string to Guid when saving to the database
                    v => Guid.Parse(v),
                    // Convert Guid to string when reading from the database
                    v => v.ToString()
                );
            modelBuilder.Entity<Brand>()
                .Property(e => e.Id)
                .HasConversion(
                    // Convert string to Guid when saving to the database
                    v => Guid.Parse(v),
                    // Convert Guid to string when reading from the database
                    v => v.ToString()
                );
        }
    }
}
