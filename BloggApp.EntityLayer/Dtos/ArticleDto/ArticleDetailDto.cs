using BlogApp.EntityLayer.Dtos.CommentDto;
using BlogApp.EntityLayer.Dtos.TagDto;
using BlogApp.EntityLayer.Dtos.UserDto;
using BloggApp.EntityLayer.Concrete;


namespace BlogApp.EntityLayer.Dtos.ArticleDto
{
    public class ArticleDetailDto
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleDescription { get; set; }
        public string UserName { get; set; }
        public List<CommentResultDto> Comments { get; set; }
        public List<TagResultDto> Tags { get; set; }
    }
}
