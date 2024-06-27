using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloggApp.EntityLayer.Concrete;


namespace BlogApp.EntityLayer.Dtos.ArticleDto
{
    public class ArticleResultDto
    {
        public string ArticleTitle { get; set; }
        public string ArticleDescription { get; set; }
    }
}
