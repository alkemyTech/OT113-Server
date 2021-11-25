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
        private readonly ActivitiesRepository _repository;

        public ActivityBusiness(ActivitiesRepository repository)
        {
            _repository = repository;
        }

        public void AddActivity() { }
        public void RemoveActivity() { }
        public Activity GetActivityById() { throw new NotImplementedException(); }
        public async Task <IEnumerable<Activity>> GetAllActivities() { throw new NotImplementedException(); }
    }
}
