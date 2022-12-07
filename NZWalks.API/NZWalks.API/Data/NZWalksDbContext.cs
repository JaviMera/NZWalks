using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using System.Xml;

namespace NZWalks.API.Data
{
    public sealed class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.Role)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);

            var writerRole = new Models.Domain.Role
            {
                Id = Guid.NewGuid(),
                Name = "writer"
            };

            var readerRole = new Models.Domain.Role
            {
                Id = Guid.NewGuid(),
                Name = "reader"
            };

            modelBuilder.Entity<Role>().HasData(writerRole, readerRole);

            var readerUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Joe",
                LastName = "Doe",
                EmailAddress = "joe@doe.com",
                Username = "joedoe",
                Password = "sdFD78s.s#*Flfs-ww",
            };

            var writerUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Joelina",
                LastName = "Doeina",
                EmailAddress = "joeline@doelina.com",
                Username = "joelinadoelina",
                Password = "sdFD78s.s#*Flfs-ww",
            };

            modelBuilder.Entity<User>().HasData(readerUser, writerUser);

            modelBuilder.Entity<User_Role>().HasData(new User_Role
            {
                Id = Guid.NewGuid(),
                RoleId = readerRole.Id,
                UserId = readerUser.Id
            },
            new  User_Role
            {
                Id = Guid.NewGuid(),
                RoleId = writerRole.Id,
                UserId = writerUser.Id
            });
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalksDifficulty { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }
    }
}
