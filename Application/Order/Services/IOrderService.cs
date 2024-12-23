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
        /// Добавление нового заказа.
        /// </summary>
        /// <param name="order">Данные заказа.</param>
        /// <returns>Идентификатор заказа.</returns>
        Task<long> CreateAsync(OrderModel order,CancellationToken cancellationToken);
    }
}
