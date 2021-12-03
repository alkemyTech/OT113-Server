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
    public class SlidesBusiness : ISlidesBusiness
    {
        private readonly IRepository<Slides> _repository;

        public SlidesBusiness(IRepository<Slides> repository)
        {
            _repository = repository;
        }

        public Slides FindById(int id)
        {
            return  _repository.GetById(id) != null ? _repository.GetById(id) : null;

        }
    }
}
