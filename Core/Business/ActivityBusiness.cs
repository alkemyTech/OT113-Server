using System;
using Entities;
using Repositories;
using Core.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helper;
using System.Security.Cryptography;
using Core.Models.DTOs;
using Core.Mapper;

namespace Core.Business
{
    public class ActivityBusiness : IActivityBusiness
    {
        private readonly IRepository<Activity> _repository;
        private readonly IEntityMapper _mapper;

        public ActivityBusiness(IRepository<Activity> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddActivity(ActivitiesDto activitie) 
        {
            var activitieMapped = _mapper.ActivitieMapDto(activitie);
            _repository.Save(activitieMapped);
        }
        public void RemoveActivity(int id) { }
        public void UpdateActivity(Activity activity) { }
        public Activity GetActivityById() { throw new NotImplementedException(); }
        public async Task <IEnumerable<Activity>> GetAllActivities() { throw new NotImplementedException(); }
    }
}
