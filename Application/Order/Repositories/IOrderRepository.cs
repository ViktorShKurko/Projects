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
        /// <summary>
        /// Добавить заказ.
        /// </summary>
        /// <param name="model">Данные о заказе.</param>
        /// <returns>Идентификатор заказа</returns>
        Task<long> AddAsync(OrderModel model);

        /// <summary>
        /// Обновить данные заказа.
        /// </summary>
        /// <param name="model">Данные о заказе.</param>
        /// <returns></returns>
        Task UpdateAsync(OrderModel model);

        /// <summary>
        /// Удалить заказ.
        /// </summary>
        /// <param name="id">Идентификатор заказа.</param>
        /// <returns></returns>
        Task DeleteAsync(long id);

        /// <summary>
        /// Возвращает заказ по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        Task<OrderModel> GetByIdAsync(long id);
    }
}
                                                                                                                                            