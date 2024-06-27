using BlogApp.CoreLayer.DataAccessLayer.Abstract;
using BlogApp.CoreLayer.DataAccessLayer.Concrete.EntityFramework;
using BlogApp.DataAccessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos.ArticleDto;
using BlogApp.EntityLayer.Dtos.CommentDto;
using BlogApp.EntityLayer.Dtos.TagDto;
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
                var article = context.Articles
                    .Include(a => a.User)
                    .Include(a => a.Comments)
                    .Include(a => a.Tags)
                    .Where(a => a.ArticleId == articleId)
                    .Select(a => new ArticleDetailDto
                    {
                        ArticleId = a.ArticleId,
                        ArticleTitle = a.ArticleTitle,
                        ArticleDescription = a.ArticleDescription,
                        UserId = a.UserId,
                        UserName = a.User.UserName!,
                        Comments = a.Comments.Select(c => new CommentResultDto
                        {
                            CommentText = c.CommentText
                        }).ToList(),
                        Tags = a.Tags.Select(t => new TagResultDto
                        {
                            TagTitle = t.TagTitle
                        }).ToList()
                    })
                    .SingleOrDefault();

                return article!;
            }
        }

    }

}
