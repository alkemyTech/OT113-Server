using Core.Models.DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Interfaces
{
    public interface ICommentBusiness
    {
        Task<IEnumerable<Comment>> GetAll();
        CommentDtoForCreation AddComment(CommentDtoForCreation comment);
    }
}
