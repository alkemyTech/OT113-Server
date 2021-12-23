using Core.Business.Interfaces;
using Core.Mapper;
using Core.Models.DTOs;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class CommentBusiness : ICommentBusiness
    {
        private readonly IRepository<Comment> _repository;
        private readonly IEntityMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<News> _newsRepository;

        public CommentBusiness(IRepository<Comment> repository, IEntityMapper mapper, IRepository<User> userRepository, IRepository<News> newsRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _newsRepository = newsRepository;
        }

        public CommentDtoForCreation AddComment(CommentDtoForCreation comment)
        {
            var user = _userRepository.GetById(comment.userId);
            var news = _newsRepository.GetById(comment.newsId);
            if(user != null && news != null)
            {
                var mappedComment = _mapper.MapCommentDtoForCreationToComment(comment);
                _repository.Save(mappedComment);

                return comment;
            }

            return null;
        }

        public Comment DeleteComment(Comment comment, string token)
        {
            if(UserValidation(token, comment))
            {
                _repository.Delete(comment.Id);
                return comment;
            }

            return null;
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Comment GetCommentById(int id)
        {
            return _repository.GetById(id);
        }

        public Comment UpdateComment(Comment comment, CommentsDto commentDto, string token)
        {
            if(UserValidation(token, comment))
            {
                comment.Body = commentDto.Body;
                _repository.Update(comment);

                return comment;
            }

            return null;
        }

        private bool UserValidation(string token, Comment comment)
        {
            var handler = new JwtSecurityTokenHandler();
            var stringSplit = token.Split(' ');
            var Token = handler.ReadJwtToken(stringSplit[0]);
            var claimsUserId = Token.Claims.Where(x => x.Type == "nameid").FirstOrDefault();
            var userRole = Token.Claims.Where(x=>x.Type =="role").FirstOrDefault().Value;
            var id = int.Parse(claimsUserId.Value);

            return (userRole == "Admin" || id == comment.userId);
        }
    }
}
