using CardShop.Domain.Enum;
using CardShop.Domain.Helpers;
using CardShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<GraphicsCard> GraphicsCard { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {

                builder.HasData(new User
                {
                    Id = 1,
                    Name = "Tekkin",
                    Password = HashPasswordHelper.HashPassowrd("123456"),
                    Role = Role.Admin
                });
                builder.HasData("Users");
                builder.HasKey(x => x.Id);

                builder.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}
