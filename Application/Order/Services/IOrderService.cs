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
        Task<long> CreateOrUpdateAsync(OrderModel order,CancellationToken cancellationToken);

        /// <summary>
        /// Получить заказ по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор заказа.</param>
        /// <returns>Заказ</returns>
        Task<OrderModel> GetByIdAsync(long id);

        /// <summary>
        /// Добавить список заказов.
        /// </summary>
        /// <param name="orders">Список заказов.</param>
        /// <returns></returns>
        Task<bool> CreateOrdersAsync(ICollection<OrderModel> orders);
    }
}
