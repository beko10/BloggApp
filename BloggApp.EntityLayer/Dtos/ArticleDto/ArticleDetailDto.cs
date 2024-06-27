using BlogApp.EntityLayer.Dtos.CommentDto;
using BlogApp.EntityLayer.Dtos.TagDto;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.EntityLayer.Dtos.ArticleDto
{
    public class ArticleDetailDto
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleDescription { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<CommentResultDto> Comments { get; set; }
        public List<TagResultDto> Tags { get; set; }
    }
}
