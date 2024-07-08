using BlogApp.DataAccessLayer.Abstract;
using BlogApp.DataAccessLyaer.Abstract;
using BlogApp.DataAccessLyaer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogAppContext _context;
        private EfArticleDal _articleDal;
        private EfCommentDal _commentDal;
        private EfTagDal _tagDal;   
        public UnitOfWork(BlogAppContext context)
        {
            _context = context;
        }

        public IArticleDal Articles => _articleDal ?? new EfArticleDal(_context);

        public ICommentDal Comments => _commentDal ?? new EfCommentDal(_context);

        public ITagDal Tags => _tagDal ?? new EfTagDal(_context);   

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}
