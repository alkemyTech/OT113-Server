using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Core.Models.DTOs;
using Entities;

namespace Core.Business.Interfaces
{
    public interface ICategoryBusiness
    {

        CategoryDto GetCategoryById(int id);  
        Task<IEnumerable<CategoryDtoGetAllResponse>> GetAllCategories();
        void addCategory(CategoryDto category);

        Category GetCategoryById2(int id);

        void UpdateCategory(Category categorie, CategoryDto update);

    }
    

}
