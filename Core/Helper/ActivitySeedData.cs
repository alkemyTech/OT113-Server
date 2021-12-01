using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class ActivitySeedData
    {
        public static void ActivitySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasData(new Activity()
            {
                Id = 1,
                Name = "TestName",
                Content = "TestContent",
                Image = "TestImage"
            });
        }
    }
}
