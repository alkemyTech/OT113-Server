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
<<<<<<< Updated upstream

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedActivity(modelBuilder);

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
=======
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }

        private void SeedNews(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 11; i++)
            {
                modelBuilder.Entity<News>().HasData(new News
                {
                    Id = i,
>>>>>>> Stashed changes
                });
            };
        }
    }
}
