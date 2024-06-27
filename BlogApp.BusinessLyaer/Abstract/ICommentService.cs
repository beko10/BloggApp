using BlogApp.EntityLayer.Dtos.CommentDto;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        Comment GetById(int id);
        void Delete(Comment comment);
        void Add(AddCommentDto comment);
        void Update(UpdateCommentDto comment);
    }
}
