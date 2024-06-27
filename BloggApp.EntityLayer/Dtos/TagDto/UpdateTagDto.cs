using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.EntityLayer.Dtos.TagDto
{
    public class UpdateTagDto
    {
        public int TagId { get; set; }
        public string TagTitle { get; set; }
    }
}
