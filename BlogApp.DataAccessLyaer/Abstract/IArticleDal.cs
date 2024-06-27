using BloggApp.EntityLayer.Concrete;
using BlogApp.CoreLayer.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.EntityLayer.Dtos.ArticleDto;

namespace BlogApp.DataAccessLyaer.Abstract
{
    public interface IArticleDal:IEntityRepository<Article>
    {
        public ArticleDetailDto GetAllArticlesWithDetails(int articleId);
    }
}
