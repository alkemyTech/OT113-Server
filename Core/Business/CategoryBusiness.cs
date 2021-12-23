using Abstractions;
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
        public Category DeleteCategorie(Category categorie)
        {
            _repository.Delete(categorie.Id);
            return categorie;
            
        }
        public CategoryDto GetCategoryById(int id)
        {

            Category category = _repository.GetById(id);
            return _mapper.mapCategoryModeltoDto(category);
        }

        public Category GetCategoryById2(int id)
        {
            return _repository.GetById(id);

        }

        public void UpdateCategory(Category category, CategoryDtoPostRequest update)
        {
            _mapper.UpdateMapCategories(category, update);
            _repository.Update(category);

        }

        public async Task<IEnumerable<CategoryDtoGetAllResponse>> GetAllCategories(IPaginationFilter filter)
        {

            var categories = await _repository.PaginatedGetAll(filter);

            var categoriesDto = _mapper.mapCategoriesNamesModelToDto(categories);

            return categoriesDto;

        }

        public CategoryDto addCategory(CategoryDtoPostRequest category)
        {
            var newCat = _mapper.mapNewCategory(category);

            var categoryDtoresponse = _mapper.mapCategoryModeltoDto(newCat);

            _repository.Save(newCat);

            return categoryDtoresponse;
        }

        public int CountCategories(){

            return _repository.Count();
        }

    }

}

