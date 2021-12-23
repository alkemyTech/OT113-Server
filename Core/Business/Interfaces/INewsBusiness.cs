using Abstractions;
using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces
{
    public interface INewsBusiness
    {
        News GetNewsById(int id);
        IEnumerable<CommentsDto> GetCommentByNews(int id);
        void AddNews(NewNewsDto news);
        void UpdateNews(News news, NewNewsDto newsDto);
        News DeleteNews(News news);

        Task<IEnumerable<NewsDto>> GetAllNews(IPaginationFilter paginationFilter);
        int CountNews();
    }
}
