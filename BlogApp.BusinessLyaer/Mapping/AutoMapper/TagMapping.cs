using AutoMapper;
using BlogApp.EntityLayer.Dtos.TagDto;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Mapping.AutoMapper
{
    public class TagMapping:Profile
    {
        public TagMapping()
        {
            CreateMap<Tag,TagResultDto>().ReverseMap();
            CreateMap<Tag,AddTagDto>().ReverseMap();    
            CreateMap<Tag,UpdateTagDto>().ReverseMap(); 
        }
    }
}
