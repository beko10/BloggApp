using BlogApp.CoreLayer.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.CoreLayer.DataAccessLayer.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
     where TEntity : class, new()
     where TContext : DbContext
    {
        private readonly TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
            
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
         
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return (_context.Set<TEntity>().FirstOrDefault(filter))!;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null
                ? _context.Set<TEntity>()
                : _context.Set<TEntity>().Where(filter);
        }
    }

}
