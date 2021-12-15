using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Business.Interfaces
{
    public interface ICategoryBusiness
    {
        CategoryDto GetCategoryById(int id);  
        Task<IEnumerable<CategoryDtoGetAllResponse>> GetAllCategories();
        void addCategory(CategoryDto category);
        void RemoveCategory(int id);
    }
    
}
