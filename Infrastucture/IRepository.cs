using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture
{
    public interface IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        /// <summary>
        /// Возвращает все элементы сущности.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Возвращает элементы сущности соответствующие фильтру. 
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicat);

        /// <summary>
        /// Получить элеменот по идентификатору.
        /// </summary>
        /// <param name="Id">Сущность.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(long Id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Обновление.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Удаление.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param> 
        /// <returns></returns>
        Task DeleteAsync(long id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление списка.
        /// </summary>
        /// <param name="entities">Список добавляемых элементов.</param>
        /// <returns></returns>
        Task AddRangeAsync(ICollection<TEntity> entities);
    }
}
