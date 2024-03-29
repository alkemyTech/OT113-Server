﻿using Abstractions;
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
        Task<IEnumerable<CategoryDtoGetAllResponse>> GetAllCategories(IPaginationFilter filter);
        CategoryDto addCategory(CategoryDtoPostRequest category);
        Category GetCategoryById2(int id);
        void UpdateCategory(Category categorie, CategoryDtoPostRequest update);
        Category DeleteCategorie(Category categorie);
        int CountCategories();
    }
    
}
