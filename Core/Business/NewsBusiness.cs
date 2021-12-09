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
    public class NewsBusiness: INewsBusiness
    {
        private readonly IRepository<News> _repository;

        public NewsBusiness(IRepository<News> repository)
        {
            _repository = repository;
        }

        public void AddNews() { }
        public void RemoveNews(int id) { }
        public void UpdateNews(News news) { }

        public News GetNewsById(int id) 
        {
            return _repository.GetById(id);
        }
        public async Task<IEnumerable<News>> GetAllNews() { throw new NotImplementedException(); }
    }
}

