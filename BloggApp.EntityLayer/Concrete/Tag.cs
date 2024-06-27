using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggApp.EntityLayer.Concrete
{

    public class Tag
    {
        public int TagId { get; set; }
        public string TagTitle { get; set; }

        // Navigation properties
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }


}
