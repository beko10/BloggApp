using AutoMapper;
using BlogApp.EntityLayer.Dtos.CommentDto;
using BloggApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLyaer.Mapping.AutoMapper
{
    public class CommentMapping:Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment,CommentResultDto>().ReverseMap();
            CreateMap<Comment,AddCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
        }
    }
}
