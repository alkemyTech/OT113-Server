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
            SeedUsers(modelBuilder);
            SeedNews(modelBuilder);
            SeedActivity(modelBuilder);
            SeedMembres(modelBuilder);
            SeedTestimonals(modelBuilder);
            SeedCategories(modelBuilder);
        }
      
        private void SeedUsers(ModelBuilder modelBuilder)
        {             
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                firstName = "TestNameUser",
                lastName = "TestLastNameUser",
                Email = "Test@email.user",
                Password = "TestLastPassUser",
                Photo = "TestPhoto",
                roleId = 1,
                isDelete = false,
                modifiedAt = DateTime.Now

            },new User()
            {
                Id = 2,
                firstName = "TestNameUser",
                lastName = "TestLastNameUser",
                Email = "Test@email.user",
                Password = "TestLastPassUser",
                Photo = "TestPhoto",
                roleId = 2,
                isDelete = false,
                modifiedAt = DateTime.Now

            },new User() 
            {
                Id = 3,
                firstName = "TestNameUser",
                lastName = "TestLastNameUser",
                Email = "Test@email.user",
                Password = "TestLastPassUser",
                Photo = "TestPhoto",
                roleId = 1,
                isDelete = false,
                modifiedAt = DateTime.Now
            }); 
        }

        private void SeedNews(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasData(new News()
            {
                Id = 1,
                Name = "TestNameNews",
                Content = "TestContentNews",
                Image = "TestImageNews",
                CategoryId = 1,
                isDelete = false,
                modifiedAt = DateTime.Now

            }, new News()
            {
                Id = 2,
                Name = "TestNameNews",
                Content = "TestContentNews",
                Image = "TestImageNews",
                CategoryId = 2,
                isDelete = false,
                modifiedAt = DateTime.Now

            }, new News()
            {
                Id = 3,
                Name = "TestNameNews",
                Content = "TestContentNews",
                Image = "TestImageNews",
                CategoryId = 1,
                isDelete = false,
                modifiedAt = DateTime.Now
            });
        }

        private void SeedActivity(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++)
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

        private void SeedMembres(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++)
            {
                modelBuilder.Entity<Member>().HasData(new Member
                {   

                    Id = i,
                    Name = "TestNameMembers",
                    FacebookUrl = "www.TestUrl.Members1",
                    InstagramUrl = "www.TestUrl.Members2",
                    LinkedinUrl = "www.TestUrl.Members3",
                    Image = "TestImageMembers",
                    Description = "TestDescriptionMembers",
                    isDelete = false,
                    modifiedAt = DateTime.Now

                });
            };
        }

        private void SeedTestimonals(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++)
            {
                modelBuilder.Entity<Testimonials>().HasData(new Testimonials()
                {
                    Id = i,
                    Name = "TestNameTestimonals",
                    Content = "TestContentTestimonals",
                    Image = "TestImageTestimonals",
                    modifiedAt = DateTime.Now
                });
            }
        }

        private void SeedCategories(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++)
            {
                modelBuilder.Entity<Category>().HasData(new Category
                {
                    Id = i,
                    Name = "TestNameCategory",
                    Description = "TestContentCategory",
                    Image = "TestImageCategory",
                    isDelete = false,
                    modifiedAt = DateTime.Now
                });
            }
        }

    }
}
