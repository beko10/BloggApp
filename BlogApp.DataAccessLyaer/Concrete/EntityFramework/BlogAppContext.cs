using BloggApp.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DataAccessLyaer.Concrete.EntityFramework
{
    public class BlogAppContext : IdentityDbContext<AppUser, AppRole, string>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSı\SQLEXPRESS;Database=MyBlogApp;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ara tablo için konfigürasyon
            modelBuilder.Entity<Article>()
                .HasMany(a => a.Tags)
                .WithMany(t => t.Articles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticleTag",
                    j => j
                        .HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_ArticleTag_Tags_TagId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Article>()
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .HasConstraintName("FK_ArticleTag_Articles_ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                );

            // Seed Users
            var hasher = new PasswordHasher<AppUser>();
            var user1 = new AppUser
            {
                Id = "1",
                UserName = "user1",
                NormalizedUserName = "USER1",
                Email = "user1@example.com",
                NormalizedEmail = "USER1@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Password123!")
            };

            modelBuilder.Entity<AppUser>().HasData(user1);

            // Seed Articles
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    ArticleId = 1,
                    ArticleTitle = "First Article",
                    ArticleDescription = "This is the first article",
                    UserId = user1.Id,
                },
                new Article
                {
                    ArticleId = 2,
                    ArticleTitle = "Second Article",
                    ArticleDescription = "This is the second article",
                    UserId = user1.Id,
                }
            );

            // Seed Tags
            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1, TagTitle = "Technology" },
                new Tag { TagId = 2, TagTitle = "Science" }
            );

            // Seed Comments
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    CommentId = 1,
                    CommentText = "This is a first comment",
                    ArticleId = 1
                },
                new Comment
                {
                    CommentId = 2,
                    CommentText = "This is a second comment",
                    ArticleId = 2
                }
            );
        }

    }
}
