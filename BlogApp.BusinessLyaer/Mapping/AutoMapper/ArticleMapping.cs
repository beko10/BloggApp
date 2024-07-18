using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.EntityLayer.Dtos.ArticleDto;
using BloggApp.EntityLayer.Concrete;

namespace BlogApp.BusinessLyaer.Mapping.AutoMapper
{
    public class ArticleMapping : Profile
    {
        public ArticleMapping()
        {
           

            CreateMap<Article,ArticleResultDto>().ReverseMap();

            CreateMap<Article,AddArticleDto>().ReverseMap();    

            CreateMap<Article, UpdateArticleDto>()
                 .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                 .ReverseMap();    

            //CreateMap<Article, ArticleDetailDto>()
            //    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            //    .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
            //    .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
            //    .ReverseMap();

      
        }
    }
}
