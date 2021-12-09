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
    public class CommentBusiness : ICommentBusiness
    {
        private readonly IRepository<Comment> _repository;
        private readonly IEntityMapper _mapper;

        public CommentBusiness(IRepository<Comment> repository, IEntityMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddComment(CommentDtoForCreation comment)
        {
            var mappedComment = _mapper.MapCommentDtoForCreationToComment(comment);
            _repository.Save(mappedComment);
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
