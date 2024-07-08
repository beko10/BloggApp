using BlogApp.DataAccessLyaer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLayer.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleDal Articles { get; }
        ICommentDal Comments { get; }
        ITagDal Tags { get; }

        int Commit();
    }
}
