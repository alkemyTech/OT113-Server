using System;
using Core.Models.DTOs;

namespace Core.Business.Interfaces
{
    public interface ICategoryBusiness
    {
        CategoryDto GetCategoryById(int id);
    }

}
