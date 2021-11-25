using Abstractions;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ActivitiesRepository : Repository<Activity>
    {
        private readonly IDbContext<Activity> _context;

        public ActivitiesRepository(IDbContext<Activity> context) :base(context)
        {
            _context = context;
        }
    }
}
