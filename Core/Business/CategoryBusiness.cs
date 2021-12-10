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
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IRepository<Category> _repository;
        private readonly IEntityMapper _mapper;

        public CategoryBusiness(IRepository<Category> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddCategory() { }
        public void RemoveCategory(int id) { }
        public void UpdateCategory(Category activity) { }


        public CategoryDto GetCategoryById(int id)
        {

            Category category = _repository.GetById(id);
            return _mapper.mapCategoryModeltoDto(category);
        }

        public Category GetCategoryById()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDtoGetAllResponse>> GetAllCategories()
        {

            var categories = await _repository.GetAll();

            var categoriesDto = _mapper.mapCategoriesNamesModelToDto(categories);

            return categoriesDto;

        }

        public void addCategory(CategoryDto category)
        {
            var newCat = _mapper.mapNewCategory(category);

            _repository.Save(newCat);
        }

    }

}

