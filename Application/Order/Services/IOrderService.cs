using TestWorkTask.Models;

namespace WorkTask.Application.Order.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Создание или обновление заказа.
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
        /// Массове добавление и обновление заказов. С использованием стандартных методов EF.
        /// </summary>
        /// <param name="orders">Список заказов.</param>
        /// <returns></returns>
        Task<bool> CreateOrdersAsync(ICollection<OrderModel> orders);

        /// <summary>
        /// Массове добавление и обновление заказов. С использованием расширения EFCore.BulkExtensions.
        /// </summary>
        /// <param name="orders">Список заказов.</param>
        /// <returns></returns>
        Task CreateOrdersWithBulkAsync(ICollection<OrderModel> orders);
    }
}
