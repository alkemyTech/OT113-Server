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
            SeedCategories(modelBuilder);
            SeedComments(modelBuilder);
            SeedContact(modelBuilder);
            SeedMembres(modelBuilder);
            SeedNews(modelBuilder);
            SeedOrganization(modelBuilder);
            SeedRoles(modelBuilder);
            SeedSlides(modelBuilder);
            SeedTestimonals(modelBuilder);
            SeedUsers(modelBuilder);
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
                    Name = "TestName",
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

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(new Roles() 
            {   
                Id = 1,
                Name = "Admin",
                Description = "Admin",              

            },new Roles() 
            {
                Id = 2,
                Name = "User",
                Description = "User"
            });
        }
        
        private void SeedOrganization(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().HasData(new Organization()
            {
                Id = 1,
                Name = "NameTestOrganization",
                Image = "ImageTestOrganization",
                Address = "AddresTestOrganization",
                Phone = "123456789",
                Email = "Organization@test.com",
                WelcomeText = "WelcomTestOrganization",
                AboutUsText = "Organization of ORGANIZATIONS",
                Facebook = "@OrganizationF",
                Linkedin = "@OrganizationL",
                Instagram = "@OrganizationI",
                isDelete = false,
                modifiedAt = DateTime.Now

            },new Organization() 
            {
                Id = 2,
                Name = "NameTestOrganization",
                Image = "ImageTestOrganization",
                Address = "AddresTestOrganization",
                Phone = "987654321",
                Email = "Organization@test2.com",
                WelcomeText = "WelcomTestOrganization",
                AboutUsText = "Organization of ORGANIZATIONS",
                Facebook = "@OrganizationFa",
                Linkedin = "@OrganizationLi",
                Instagram = "@OrganizationIn",
                isDelete = false,
                modifiedAt = DateTime.Now
            });
        }

        private void SeedContact(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>().HasData(new Contacts()
            {
                Id=1,
                Name = "ContactTestName",
                Phone = 123456789,
                Email = "Contact@test.com",
                Message = "TestMessage",
                isDelete = false,
                modifiedAt = DateTime.Now

            },new Contacts() 
            {
                Id = 2,
                Name = "ContactTestName",
                Phone = 987654321,
                Email = "Contact@test2.com",
                Message = "TestMessage",
                isDelete = false,
                modifiedAt = DateTime.Now
            });
        }

        private void SeedSlides(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++)
            {
                modelBuilder.Entity<Slides>().HasData(new Slides()
                {
                    Id = i,
                    ImgUrl = "Https//test1.com",
                    Text = "TestTextSlides",
                    Order = (i - 1),
                    OrganizationId = (i - 1),
                    isDelete = false,
                    modifiedAt = DateTime.Now
                });
            };
        }

        private void SeedComments(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++) 
            {
                modelBuilder.Entity<Comment>().HasData(new Comment()
                {
                    Id = i,
                    userId = (i - 1),
                    Body = "TestBodyComments",
                    newsId = (i - 1),
                    isDelete = false,
                    modifiedAt = DateTime.Now
                });
            };
        }
    }
}
