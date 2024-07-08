using Autofac;
using AutoMapper;
using BlogApp.BusinessLyaer.Abstract;
using BlogApp.BusinessLyaer.Concrete;
using BlogApp.DataAccessLayer.Abstract;
using BlogApp.DataAccessLayer.Concrete;
using BlogApp.DataAccessLyaer.Abstract;
using BlogApp.DataAccessLyaer.Concrete.EntityFramework;
using BloggApp.EntityLayer.Concrete;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;
using Module = Autofac.Module;


namespace BlogApp.BusinessLyaer.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Db context
            builder.RegisterType<BlogAppContext>().AsSelf().InstancePerLifetimeScope();

            // Identity services
            builder.RegisterType<UserManager<AppUser>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<SignInManager<AppUser>>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<RoleManager<IdentityRole>>().AsSelf().InstancePerLifetimeScope();

            // ISessionManagementService eklenmesi
            builder.RegisterType<SessionManagementManager>().As<ISessionManagementService>().SingleInstance();

            // Article
            builder.RegisterType<ArticleManager>().As<IArticleService>().SingleInstance();
            builder.RegisterType<EfArticleDal>().As<IArticleDal>().SingleInstance();

            // Comment
            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();

            // Tag
            builder.RegisterType<TagManager>().As<ITagService>().SingleInstance();
            builder.RegisterType<EfTagDal>().As<ITagDal>().SingleInstance();

            //UoF
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();  

            // Automapper
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<Profile>()
                .As<Profile>();

            builder.Register(context =>
            {
                var profiles = context.Resolve<IEnumerable<Profile>>();
                var config = new MapperConfiguration(cfg =>
                {
                    foreach (var profile in profiles)
                    {
                        cfg.AddProfile(profile);
                    }
                });

                return config;
            }).SingleInstance();

            builder.Register(context =>
            {
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();
        }
    }

}
