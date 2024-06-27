using AutoMapper;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.DataAccessLyaer.Abstract;
using BlogApp.DataAccessLyaer.Concrete.EntityFramework;
using BlogApp.EntityLayer.Dtos.ArticleDto;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        private readonly IMapper _mapper;
        private readonly ITagDal _tagDal;

        public ArticleManager(IArticleDal articleDal, IMapper mapper, ITagDal tagDal)
        {
            _articleDal = articleDal;
            _mapper = mapper;
            _tagDal = tagDal;
        }

        public void Add(AddArticleDto article)
        {
            var addedArticle = _mapper.Map<Article>(article);
            addedArticle.UserId = "1";
            foreach (var tagTitle in article.TagText)
            {
                if (!string.IsNullOrEmpty(tagTitle.TagTitle))
                {
                    var tag = _tagDal.Get(t => t.TagTitle == tagTitle.TagTitle);
                    if (tag == null)
                    {
                        tag = new Tag { TagTitle = tagTitle.TagTitle };
                        _tagDal.Add(tag);
                    }
                    addedArticle.Tags.Add(tag);
                }
            }
            _articleDal.Add(addedArticle);
        }

        public void Delete(Article article)
        {
            _articleDal.Delete(article);
        }

        public List<ArticleResultDto> GetAll()
        {
            var articles = _articleDal.GetAll();
            return _mapper.Map<List<ArticleResultDto>>(articles);

        }

        public Article GetById(int id)
        {
            return _articleDal.Get(x => x.ArticleId == id);
        }


        public void Update(UpdateArticleDto article)
        {
            var updetedArticle = _mapper.Map<Article>(article);
            updetedArticle.UserId = "1";
            _articleDal.Update(updetedArticle);
        }

        public ArticleDetailDto GetAllArticlesWithDetails(int articleId)
        {
            var articleDetail = _mapper.Map<ArticleDetailDto>(_articleDal.GetAllArticlesWithDetails(articleId));
            return articleDetail;

        }
    }
}
