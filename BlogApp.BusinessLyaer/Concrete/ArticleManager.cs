using AutoMapper;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.DataAccessLyaer.Abstract;
using BlogApp.DataAccessLyaer.Concrete.EntityFramework;
using BlogApp.EntityLayer.Dtos.ArticleDto;
using BlogApp.EntityLayer.Dtos.TagDto;
using BloggApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ArticleManager(IArticleDal articleDal, IMapper mapper, ITagService tagService, IHttpContextAccessor httpContextAccessor)
        {
            _articleDal = articleDal;
            _mapper = mapper;
            _tagService = tagService;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Add(AddArticleDto article)
        {
            var addedArticle = _mapper.Map<Article>(article);
            addedArticle.UserId = "1";
            AddArticleWithTag(article, addedArticle);   
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

        private void AddArticleWithTag(AddArticleDto addArticleDto,Article article)
        {
            foreach (var tagTitle in addArticleDto.TagTitle)
            {
                if (!string.IsNullOrEmpty(tagTitle.TagTitle))
                {
                    var tag = _tagService.GetByTagName(tagTitle.TagTitle);
                    if (tag == null)
                    {
                        tag = new TagResultDto { TagTitle = tagTitle.TagTitle };
                        var newTag = _mapper.Map<AddTagDto>(tag);
                        _tagService.Add(newTag);
                    }
                    article.Tags.Add(_mapper.Map<Tag>(tag));
                }
            }
        }
    }
}
