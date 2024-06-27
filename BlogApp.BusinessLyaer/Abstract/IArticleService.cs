using BlogApp.EntityLayer.Dtos.ArticleDto;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Abstract
{
    public interface IArticleService
    {
        List<ArticleResultDto> GetAll();
        Article GetById(int id);
        void Delete(Article article);
        void Add(AddArticleDto article);
        void Update(UpdateArticleDto article);

        public ArticleDetailDto GetAllArticlesWithDetails(int articleId);
    }
}
