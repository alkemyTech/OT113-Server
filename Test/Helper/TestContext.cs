using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Helper
{
    public class TestContext
    {
        public ApiDbContext GetTestContext(string testDb)
        {
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(testDb)
                .Options;
            var dbcontext = new ApiDbContext(options);
            return dbcontext;
        }

      
    }
}
