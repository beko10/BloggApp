using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.EntityLayer.Dtos.CommentDto
{
    public class UpdateCommentDto
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int ArticleId { get; set; }

    }
}
