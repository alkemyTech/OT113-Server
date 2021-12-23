using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models.DTOs;
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
        private readonly IEntityMapper _mapper;

        public ActivityBusiness(IRepository<Activity> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Activity AddActivity(ActivitiesDto activitie)
        {
            var activitieMapped = _mapper.ActivitieMapDto(activitie);
            _repository.Save(activitieMapped);

            return activitieMapped;
        }

        public void RemoveActivity(int id) { 

        }

        public void UpdateActivity(int id, ActivitiesDto activityDto) 
        { 
            var activity = _repository.GetById(id);
            var activityEdit = _mapper.mapActivityDtoToModelPutRequest(activity, activityDto);
            _repository.Update(activityEdit);
        }

        public Activity getActivity(int id)
        {
                
                return _repository.GetById(id);
        }

        public ActivitiesDtoForDisplay GetActivityById(int id) 
        {

            Activity activity = _repository.GetById(id);
            ActivitiesDtoForDisplay activityDto = _mapper.mapActityModelToDto(activity);
            return activityDto;
         }


        public async Task<IEnumerable<ActivityDtoGetAllResponse>> GetAllActivities() { 

            var activities = await _repository.GetAll();

            var activitiesDto = _mapper.mapActivitiesNamesModelToDto(activities);

            return activitiesDto;

        }
    }
}
