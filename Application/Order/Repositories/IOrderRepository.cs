using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestWorkTask.Models;

namespace WorkTask.Application.Order.Repositories
{

    public interface IOrderRepository
    {
        //IQueryable<Order> GetAll();

        /// <summary>
        /// Добавить заказ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<long> AddAsync(OrderModel model);

        /// <summary>
        /// Обновить данные заказа.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateAsync(OrderModel model);

        /// <summary>
        /// Удалить заказ.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Получить по внешнему идентификатору.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderModel> GetByInnerId(long id);
    }
}
                                                                                                                                            