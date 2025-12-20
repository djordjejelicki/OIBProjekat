using Microsoft.EntityFrameworkCore;
using PetShop.Application.Helpers;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;

namespace PetShop.Infrastructure.Data
{
    public class PetShopDbContext : DbContext
    { 
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options)
             : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Hashovanje lozinke
            string adminPass = PasswordHasher.HashPassword("admin123");
            string sellerPass = PasswordHasher.HashPassword("seller123");
            string minaMNGPass = PasswordHasher.HashPassword("mina123");
            string bojanSELLPass = PasswordHasher.HashPassword("bojan123");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "manager",
                    FirstName = "Main",
                    LastName = "Manager",
                    Password = adminPass,
                    Role = RoleType.Manager
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "seller",
                    FirstName = "Default",
                    LastName = "Seller",
                    Password = sellerPass,
                    Role = RoleType.Seller
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "minamng",
                    FirstName = "Mina",
                    LastName = "Dragic",
                    Password = minaMNGPass,
                    Role = RoleType.Manager
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "bojansell",
                    FirstName = "Bojan",
                    LastName = "Koledin",
                    Password = bojanSELLPass,
                    Role = RoleType.Seller
                }
            );
        }
    }
}
