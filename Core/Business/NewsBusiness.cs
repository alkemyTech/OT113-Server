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
    public class NewsBusiness: INewsBusiness
    {
        private readonly IRepository<News> _repository;
        private readonly IRepository<Comment> _comment;
        private readonly IEntityMapper _mapper;

        public NewsBusiness(IRepository<News> repository, IRepository<Comment> comment, IEntityMapper mapper)
        {
            _repository = repository;
            _comment = comment;
            _mapper = mapper;
        }

        public void AddNews(NewNewsDto news) 
        {
            var newsMapped = _mapper.NewsMapDto(news);
            _repository.Save(newsMapped);
        }

        public void RemoveNews(int id) { }
        public void UpdateNews(News news, NewNewsDto newsDto) 
        {
            var mappedNews = _mapper.UpdateNews(news, newsDto);
            _repository.Update(mappedNews);
        }

        public News GetNewsById(int id) 
        {
            return _repository.GetById(id);
        }

        public IEnumerable<CommentsDto> GetCommentByNews(int id)
        {
            var comments = _comment.GetAll().Result;

            var listComments = _mapper.MappComments(comments.Where(comment => comment.newsId == id));
            return listComments;
        }
        public async Task<IEnumerable<News>> GetAllNews() { throw new NotImplementedException(); }
    }
}

