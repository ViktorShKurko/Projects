using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;

namespace WorkTask.Application.Order.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Создание нового заказа.
        /// </summary>
        /// <param name="order">Данные о заказе.</param>
        /// <returns>Идентификатор заказа.</returns>
        Task<long> CreateAsync(OrderModel order,CancellationToken cancellationToken);

        /// <summary>
        /// Получить заказ по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор заказа.</param>
        /// <returns>Заказ</returns>
        Task<OrderModel> GetByIdAsync(long id);
    }
}
