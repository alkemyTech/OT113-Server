using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.DTOs;

namespace Core.Business.Interfaces
{
    public interface ICategoryBusiness
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();

    }
    
}
