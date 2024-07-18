using BlogApp.BusinessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos.ArticleDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        [Authorize]
        [HttpGet]
        public IActionResult GetArticleList()
        {
            var articles = _articleService.GetAll().ToList();
            return Ok(articles);
        }
        [HttpPost]
        public IActionResult AddArticle(AddArticleDto addArticleDto)
        {
            _articleService.Add(addArticleDto);
            return Ok(addArticleDto);
        }

        [HttpGet("GetAllArticlesWithDetails/{id}")]
        public IActionResult GetAllArticlesWithDetails(int id)
        {
            var result = _articleService.GetAllArticlesWithDetails(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateArticle(UpdateArticleDto updateArticleDto)
        {
            _articleService.Update(updateArticleDto);
            return Ok(updateArticleDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var deletedArticle = _articleService.GetById(id);
            _articleService.Delete(deletedArticle);
            return Ok(deletedArticle);
        }

    }
}
