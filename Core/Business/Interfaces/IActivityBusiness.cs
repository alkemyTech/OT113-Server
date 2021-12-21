using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces
{
    public interface IActivityBusiness
    {
      Activity AddActivity(ActivitiesDto activitie);

      void UpdateActivity(int id, ActivitiesDto activityDto);

      ActivitiesDtoForDisplay GetActivityById(int id);

      Activity getActivity(int id);

      Task<IEnumerable<ActivityDtoGetAllResponse>> GetAllActivities();

    }
}
