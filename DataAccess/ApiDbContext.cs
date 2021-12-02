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
<<<<<<< HEAD
            SeedTestimonals(modelBuilder);
        }
 
        private void SeedTestimonals(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++)
            {
                modelBuilder.Entity<Testimonials>().HasData(new Testimonials
                {
                    Id = i,
                    Name = "TestNameTestimonals",
                    Content = "TestContentTestimonals",
                    Image = "TestImageTestimonals",                  
=======
            SeedMembres(modelBuilder);
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
>>>>>>> d54c59c52cd228320814c2c49de309e8277fcd48
                    isDelete = false,
                    modifiedAt = DateTime.Now

                });
            };
        }
    }
}
