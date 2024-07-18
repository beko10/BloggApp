using BlogApp.CoreLayer.DataAccessLayer.Abstract;
using BlogApp.CoreLayer.DataAccessLayer.Concrete.EntityFramework;
using BlogApp.DataAccessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos.ArticleDto;
using BlogApp.EntityLayer.Dtos.CommentDto;
using BlogApp.EntityLayer.Dtos.TagDto;
using BlogApp.EntityLayer.Dtos.UserDto;
using BloggApp.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLyaer.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<BlogAppContext, Article>, IArticleDal
    {
        public EfArticleDal(BlogAppContext context) : base(context)
        {
        }

        public ArticleDetailDto GetAllArticlesWithDetails(int articleId)
        {
            using (var context = new BlogAppContext())
            {
                var articleDetail = context.Articles
                        .Include(a => a.Comments)
                        .Include(a => a.Tags)
                        .Include(a => a.User)
                        .FirstOrDefault(x => x.ArticleId == articleId);

                return new ArticleDetailDto
                {
                    ArticleId = articleDetail.ArticleId,
                    ArticleDescription = articleDetail.ArticleDescription,
                    ArticleTitle = articleDetail.ArticleTitle,
                    
                    Comments = articleDetail.Comments.Select(c => new CommentResultDto
                    {
                        CommentText = c.CommentText,

                    }).ToList(),
                    
                    Tags = articleDetail.Tags.Select(c => new TagResultDto
                    {
                        TagTitle = c.TagTitle,
                    }).ToList(),
                    UserName = articleDetail.User.UserName
                };

            }

        }

    }
}