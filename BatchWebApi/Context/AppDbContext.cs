using BatchWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BatchWebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed data / provide initial/hardcode data
            modelBuilder.Entity<Role>()
                .HasData(
                 new Role() { RoleId = 1, RoleName = "Admin" },
                 new Role() { RoleId = 2, RoleName = "Manager" },
                 new Role() { RoleId = 3, RoleName = "User" }
                 );

            modelBuilder.Entity<User>()
                .HasData(
                 new User()
                 {
                     Id = 1,
                     FirstName = "Deepak",
                     LastName = "Kumar",
                     Email = "admin@gmail.com",
                     ManagerId = 1,
                     RoleId = 1,
                     Password = "pass@123"
                 },
            new User()
            {
                Id = 2,
                FirstName = "Ajay",
                LastName = "Kumar",
                Email = "ajay@gmail.com",
                ManagerId = 1,
                RoleId = 2,
                Password = "pass@123"
            });

        }
    }
}