
namespace BloggApp.EntityLayer.Concrete
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleDescription { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
