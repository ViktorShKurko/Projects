using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;

namespace WorkTask.AppServices.Order.Helpers
{
    public interface IOrderHelper
    {
        /// <summary>
        /// Добавить или актуализировать заказ.
        /// </summary>
        /// <param name="order">Данные о заказе.</param>
        /// <returns></returns>
        Task CreateOrUpdate(OrderModel order);

        /// <summary>
        /// Добавить или актуализировать заказы.
        /// </summary>
        /// <param name="orders">Данные о заказах.</param>
        /// <returns></returns>
        Task CreateOrUpdate(OrdersModel orders);

        /// <summary>
        /// Удалить закзаз.
        /// </summary>
        /// <param name="order">Данные о заказах.</param>
        /// <returns></returns>
        Task Delete(OrderModel order);

        /// <summary>
        /// Удалить заказы.
        /// </summary>
        /// <param name="orders">Данные о заказах.</param>
        /// <returns></returns>
        Task Delete(OrdersModel orders);
    }
}
