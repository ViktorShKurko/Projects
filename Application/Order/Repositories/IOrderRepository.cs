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
        /// Обновить данные заказов.
        /// </summary>
        /// <param name="orderDtos">Список заказов.</param>
        /// <returns></returns>
        Task UpdateRangeAsync(ICollection<OrderModel> orderDtos);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        bool IsExist(long orderId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordesId"></param>
        /// <returns></returns>
        ICollection<OrderModel> GetByIds(ICollection<long> ordesId);

        /// <summary>
        /// Добавить список.
        /// </summary>
        /// <param name="orders">Список добавляемых элементов.</param>
        /// <returns></returns>
        Task AddRangeAsync(ICollection<OrderModel> orders);
    }
}
                                                                                                                                            