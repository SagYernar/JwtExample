using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokensApp.Models;

namespace TokensApp.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Login = "admin",
                    Password = "asd",
                    CreationDate = DateTime.Now
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
