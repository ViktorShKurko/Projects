namespace Domain.Models
{
    /// <summary>
    /// Товар.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Навигационное свойство.Связь с таблицой OrderProducts.
        /// </summary>
        public ICollection<OrderProduct>? OrderProducts { get; set; } 
    }
}
