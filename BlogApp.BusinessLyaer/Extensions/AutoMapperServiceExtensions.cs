using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;

namespace BlogApp.BusinessLyaer.Extensions
{
    public static class AutoMapperServiceExtensions
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
