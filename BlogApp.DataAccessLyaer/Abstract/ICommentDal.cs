using BlogApp.CoreLayer.DataAccessLayer.Abstract;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLyaer.Abstract
{
    public interface ICommentDal:IEntityRepository<Comment>
    {
    }
}
