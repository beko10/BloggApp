using BlogApp.CoreLayer.DataAccessLayer.Concrete.EntityFramework;
using BlogApp.DataAccessLyaer.Abstract;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLyaer.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<BlogAppContext, Comment>, ICommentDal
    {
        public EfCommentDal(BlogAppContext context) : base(context)
        {
        }
    }
}
