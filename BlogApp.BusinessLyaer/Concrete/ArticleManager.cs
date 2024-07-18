using AutoMapper;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.DataAccessLayer.Abstract;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ArticleManager(IArticleDal articleDal, IMapper mapper, ITagService tagService, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _articleDal = articleDal;
            _mapper = mapper;
            _tagService = tagService;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddArticleDto article)
        {
            var addedArticle = _mapper.Map<Article>(article);
            //addedArticle.UserId = GetCurrentUserId();
            AddArticleWithTag(article, addedArticle);
            _unitOfWork.Articles.Add(addedArticle);
            _unitOfWork.Commit();   
        }

        public void Delete(Article article)
        {
            _unitOfWork.Articles.Delete(article);   
            _unitOfWork.Commit();
        }

        public List<ArticleResultDto> GetAll()
        {
            var articles = _unitOfWork.Articles.GetAll();   
            return _mapper.Map<List<ArticleResultDto>>(articles);

        }

        public Article GetById(int id)
        {
            return _unitOfWork.Articles.Get(x => x.ArticleId == id);
        }


        public void Update(UpdateArticleDto article)
        {
            var updetedArticle = _mapper.Map<Article>(article);
            updetedArticle.UserId = "1";
            _unitOfWork.Articles.Update(updetedArticle);
            _unitOfWork.Commit();   
        }

        public ArticleDetailDto GetAllArticlesWithDetails(int articleId)
        {
            var articleDetail = _unitOfWork.Articles.GetAllArticlesWithDetails(articleId);
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
        private string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
