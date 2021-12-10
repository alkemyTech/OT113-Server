using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Core.Models.DTOs;

namespace Core.Business.Interfaces
{
    public interface ICategoryBusiness
    {

        CategoryDto GetCategoryById(int id);  
        Task<IEnumerable<CategoryDtoGetAllResponse>> GetAllCategories();
        void addCategory(CategoryDto category);

    }
    

}
