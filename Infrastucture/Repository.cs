using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq.Expressions;
using System.Threading;

namespace Infrastucture
{

    /// <inheritdoc/>
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        protected TContext DbContext { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }

        public Repository(TContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await DbSet.AddAsync(entity, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            DbSet.Update(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var model = await GetByIdAsync(id, cancellationToken);
            DbSet.Remove(model);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AddRangeAsync(ICollection<TEntity> entities) 
        {
            await DbSet.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync(new CancellationToken());
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
        public IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity,bool>> predicat)
        {
           // var expression = Expression.Lambda<Func<TEntity, bool>>(Expression.Call(predicat.Method));
            return DbSet.Where(predicat);
        }

        public async Task<TEntity> GetByIdAsync(long Id, CancellationToken cancellationToken)
        {
            return await DbSet.FindAsync(Id, cancellationToken);
        }
    }
}
