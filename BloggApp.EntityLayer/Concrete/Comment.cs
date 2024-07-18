

namespace BloggApp.EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; } 
    }


}
