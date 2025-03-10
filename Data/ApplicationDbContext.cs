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
                new MembershipType { Id = 1, Name = "Pay as You Go", SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0 },
                new MembershipType { Id = 2, Name = "Monthly", SignUpFee = 30, DurationInMonths = 1, DiscountRate = 10 },
                new MembershipType { Id = 3, Name = "Quarterly", SignUpFee = 90, DurationInMonths = 3, DiscountRate = 15 },
                new MembershipType { Id = 4, Name = "Annual", SignUpFee = 300, DurationInMonths = 12, DiscountRate = 20 }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Yoo Jae Yi", Birthdate = new System.DateTime(1990, 1, 1), MembershipTypeId = 1, IsSubscribedToNewsletter = true },
                new Customer { Id = 2, Name = "Woo Seul Gi", Birthdate = new System.DateTime(1995, 1, 1), MembershipTypeId = 2, IsSubscribedToNewsletter = false },
                new Customer { Id = 3, Name = "Jung Hae In", Birthdate = new System.DateTime(2000, 1, 1), MembershipTypeId = 3, IsSubscribedToNewsletter = true },
                new Customer { Id = 4, Name = "Jung So Min", Birthdate = new System.DateTime(2005, 1, 1), MembershipTypeId = 4, IsSubscribedToNewsletter = false },
                new Customer { Id = 5, Name = "Nam Joo Hyuk", Birthdate = new System.DateTime(2010, 1, 1), MembershipTypeId = 1, IsSubscribedToNewsletter = true },
                new Customer { Id = 6, Name = "Kim Seon Ho", Birthdate = new System.DateTime(2015, 1, 1), MembershipTypeId = 2, IsSubscribedToNewsletter = false },
                new Customer { Id = 7, Name = "Lee Do Hyun", Birthdate = new System.DateTime(2020, 1, 1), MembershipTypeId = 3, IsSubscribedToNewsletter = true }
            );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Shrek", Genre = "Comedy", Price = 10, ReleaseDate = new DateTime(2001, 1, 1) },
                new Movie { Id = 2, Name = "Wall-E", Genre = "Family", Price = 8, ReleaseDate = new DateTime(2008, 1, 1) },
                new Movie { Id = 3, Name = "The Godfather", Genre = "Crime", Price = 9, ReleaseDate = new DateTime(1972, 1, 1)},
                new Movie { Id = 4, Name = "The Dark Knight", Genre = "Action", Price = 12, ReleaseDate = new DateTime(2008, 1, 1)},
                new Movie { Id = 5, Name = "Love Next Door", Genre = "Romcom", Price = 11, ReleaseDate = new DateTime(2024, 1, 1)},
                new Movie { Id = 6, Name = "The Matrix", Genre = "Sci-Fi", Price = 13, ReleaseDate = new DateTime(1999, 1, 1)},
                new Movie { Id = 7, Name = "The Shawshank Redemption", Genre = "Drama", Price = 14, ReleaseDate = new DateTime(1994, 1, 1)}
            );
        }
    }
}

