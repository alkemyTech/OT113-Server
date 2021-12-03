﻿using Core.Business.Interfaces;
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
    public class SlidesBusiness : ISlidesBusiness
    {
        private readonly IRepository<Slides> _repository;
        private readonly IEntityMapper _mapper;

        public SlidesBusiness(IRepository<Slides> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Slides FindById(int id)
        {
            var slide =  _repository.GetById(id) != null ? _repository.GetById(id) : null;


            return slide;
        }

        public async Task<IEnumerable<Slides>> GetAllSlides()
        {
            return await _repository.GetAll();
        }

    }
}
