using Abstractions;
using Core.Helper;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Slides> Slides { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<User> Users { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedActivity(modelBuilder);
            SeedNews(modelBuilder);

        }

        private void SeedActivity(ModelBuilder modelBuilder)
        {
            for(int i = 1; i < 11; i++)
            {
                modelBuilder.Entity<Activity>().HasData(new Activity 
                {
                    Id = i,
                    Name = "TestNamegit",
                    Content = "TestContent",
                    Image = "TestImage",
                    isDelete = false

                });
            };
        }

        private void SeedNews(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++)
            {
                modelBuilder.Entity<News>().HasData(new News
                {
                    Id = i,
                    Name = "TestNameNews",
                    Content = "TestContentNews",
                    Image = "TestImageNews",
                    CategoryId = i,
                    isDelete = false,
                    modifiedAt = DateTime.Now

                });
            };
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++)
            {
                modelBuilder.Entity<User>().HasData(new User
                {
                    Id = i,
                    firstName = "TestNameUser",
                    lastName = "TestLastNameUser",
                    Email = "Test@email.user",
                    Password = "TestLastPassUser",
                    Photo = "TestPhoto",
                    roleId = i,
                    isDelete = false,
                    modifiedAt = DateTime.Now

                });
            };
        }
    }
}
