namespace Domain.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата регистрации заказа
        /// </summary>
        public DateTime Reistered { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; } // > 0

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Навигационное свойство.Данные о пользователе.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Навигационое свойство.Позиции заказа.
        /// </summary>
        public ICollection<OrderProduct>? Products { get; set; }
    }

    /// <summary>
    /// Позиция заказа
    /// </summary>
    public class OrderProduct 
    {
        /// <summary>
        /// Идентификатор заказа.
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// Навигационое свойство.Заказ.
        /// </summary>
        public Order? Order { get; set; }

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// Навигационое свойство.Товар.
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Quantity { get; set; } // > 0
    }
}
