using BlogApp.EntityLayer.Dtos.TagDto;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Abstract
{
    public interface ITagService
    {
        List<Tag> GetAll();
        Tag GetById(int id);
        void Delete(Tag tag);
        void Add(AddTagDto tag);
        void Update(UpdateTagDto tag);
    }
}
