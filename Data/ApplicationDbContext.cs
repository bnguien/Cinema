using Microsoft.EntityFrameworkCore;
using MyMVCApp.Models;

namespace MyMVCApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed MembershipTypes table
            modelBuilder.Entity<MembershipType>().HasData(
                new MembershipType { Id = 1, Name = "Pay As You Go", DiscountRate = 0 },
                new MembershipType { Id = 2, Name = "Monthly", DiscountRate = 10 },
                new MembershipType { Id = 3, Name = "Quarterly", DiscountRate = 15 },
                new MembershipType { Id = 4, Name = "Annual", DiscountRate = 20 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John Doe", Birthdate = new DateTime(1980, 1, 1), MembershipTypeId = 1},
                new Customer { Id = 2, Name = "Jane Doe", Birthdate = new DateTime(1985, 1, 1), MembershipTypeId = 2},
                new Customer { Id = 3, Name = "Sam Smith", Birthdate = new DateTime(1990, 1, 1), MembershipTypeId = 3}
            );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "The Shawshank Redemption"},
                new Movie { Id = 2, Name = "The Godfather"},
                new Movie { Id = 3, Name = "The Dark Knight"}
            );
        }
    }
}

