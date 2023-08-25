using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.EF
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext , new()
    {
        public void Delete(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Remove(entity);
            ctx.SaveChanges();
        }

       
        public TEntity Get(Expression<Func<TEntity, bool>> predicate, params string[] includeList)
        {
            using TContext context = new();
            IQueryable<TEntity> dbSet = context.Set<TEntity>();
            if (includeList.Length > 0)
            {
                foreach (var item in includeList)
                {
                    dbSet = dbSet.Include(item);
                }
            }
            return dbSet.SingleOrDefault(predicate);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeList)
        {
            using TContext context = new();
            IQueryable<TEntity> dbSet = context.Set<TEntity>();
            if (includeList.Length > 0)
            {
                foreach (var item in includeList)
                {
                    dbSet = dbSet.Include(item);
                }
            }

            if (predicate == null)
                return dbSet.ToList();
            return dbSet.Where(predicate).ToList();

        }

        public TEntity Insert(TEntity entity)
        {
            using var ctx = new TContext();
            var entityEntry = ctx.Set<TEntity>().Add(entity);
            ctx.SaveChanges();
            return entityEntry.Entity;
        }

        public void Update(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Update(entity);
            ctx.SaveChanges();
        }
    }
}
