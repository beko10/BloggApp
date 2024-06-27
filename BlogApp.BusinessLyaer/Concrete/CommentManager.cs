using AutoMapper;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.DataAccessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos.CommentDto;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IMapper _mapper;
        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
        }

        public void Add(AddCommentDto comment)
        {
            var addedComment = _mapper.Map<Comment>(comment);
           _commentDal.Add(addedComment);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll().ToList();    
        }

        public Comment GetById(int id)
        {
            return _commentDal.Get(x => x.CommentId == id);
        }

        public void Update(UpdateCommentDto comment)
        {
            var updatedComment = _mapper.Map<Comment>(comment);
           _commentDal.Update(updatedComment);
        }
    }
}
