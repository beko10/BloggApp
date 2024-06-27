using AutoMapper;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.DataAccessLyaer.Abstract;
using BlogApp.EntityLayer.Dtos.TagDto;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Concrete
{
    public class TagManager : ITagService
    {
        private readonly ITagDal _tagDal;
        private readonly IMapper _mapper;

        public TagManager(ITagDal tagDal, IMapper mapper)
        {
            _tagDal = tagDal;
            _mapper = mapper;
        }

        public void Add(AddTagDto tag)
        {
            var addedTag = _mapper.Map<Tag>(tag);
            _tagDal.Add(addedTag);
        }

        public void Delete(Tag tag)
        {
            _tagDal.Delete(tag);
        }

        public List<Tag> GetAll()
        {
            return _tagDal.GetAll().ToList();
        }

        public Tag GetById(int id)
        {
            return _tagDal.Get(x => x.TagId == id); 
        }

        public void Update(UpdateTagDto tag)
        {
            var updatedTag = _mapper.Map<Tag>(tag);
            _tagDal.Update(updatedTag);
        }
    }
}
