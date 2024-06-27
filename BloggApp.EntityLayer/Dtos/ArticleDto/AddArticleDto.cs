using BlogApp.EntityLayer.Dtos.TagDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.EntityLayer.Dtos.ArticleDto
{
    public class AddArticleDto
    {
        public string ArticleTitle { get; set; }
        public string ArticleDescription { get; set; }
        public string UserId { get; set; }
        public ICollection<TagResultDto> TagText { get; set; } 
    }
}
