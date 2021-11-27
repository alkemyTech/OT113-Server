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
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IRepository<Category> _repository;

        public CategoryBusiness(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public void AddCategory() { }
        public void RemoveCategory(int id) { }
        public void UpdateCategory(Category activity) { }
        public Category GetCategoryById() { }
        public async Task<IEnumerable<Category>> GetAllCategories () { }
    }
}
