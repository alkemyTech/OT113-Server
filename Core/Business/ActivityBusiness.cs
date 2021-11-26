using Core.Business.Interfaces;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class ActivityBusiness : IActivityBusiness
    {
        private readonly IRepository<Activity> _repository;

        public ActivityBusiness(IRepository<Activity> repository)
        {
            _repository = repository;
        }

        public void AddActivity() { }
        public void RemoveActivity(int id) { }
        public Activity GetActivityById() { throw new NotImplementedException(); }
        public async Task <IEnumerable<Activity>> GetAllActivities() { throw new NotImplementedException(); }
    }
}
