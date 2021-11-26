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
        private readonly Repository<News> _repository;

        public NewsBusiness(Repository<News> repository)
        {
            _repository = repository;
        }

        public void AddNews() { }
        public void RemoveNews() { }
        public News GetActivityById() { throw new NotImplementedException(); }
        public async Task<IEnumerable<News>> GetAllNews() { throw new NotImplementedException(); }
    }
}

