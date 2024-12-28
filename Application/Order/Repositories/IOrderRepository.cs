using TestWorkTask.Models;

namespace WorkTask.Application.Order.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Добавить заказ.
        /// </summary>
        /// <param name="model">Данные о заказе.</param>
        /// <returns>Идентификатор заказа.</returns>
        Task<long> AddAsync(OrderModel model);

        /// <summary>
        /// Обновить данные заказа.
        /// </summary>
        /// <param name="model">Данные о заказе.</param>
        /// <returns>Идентификатор заказа.</returns>
        Task UpdateAsync(OrderModel model);

        /// <summary>
        /// Обновить данные заказов.
        /// </summary>
        /// <param name="orderDtos">Список заказов.</param>
        /// <returns></returns>
        Task UpdateRangeAsync(ICollection<OrderModel> orderDtos);

        /// <summary>
        /// Массовое создание и обновление.
        /// </summary>
        /// <param name="ordersDto">Список заказов.</param>
        /// <returns></returns>
        Task InsertOrUpdateAsync(ICollection<OrderModel> ordersDto);

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
        /// <returns>Заказ.</returns>
        Task<OrderModel> GetByIdAsync(long id);

        /// <summary>
        /// Признак существования заказа в БД.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа.</param>
        /// <returns>Заказ есть в БД - true, заказа нет в БД - false.</returns>
        bool IsExist(long orderId);

        /// <summary>
        /// Возвращает лист заказов по идентификаторам. 
        /// </summary>
        /// <param name="ordesId">Идентификаторы заказов.</param>
        /// <returns>Лист заказов.</returns>
        ICollection<OrderModel> GetByIds(ICollection<long> ordesId);

        /// <summary>
        /// Добавить список.
        /// </summary>
        /// <param name="orders">Список добавляемых элементов.</param>
        /// <returns></returns>
        Task AddRangeAsync(ICollection<OrderModel> orders);
    }
}
                                                                                                                                            