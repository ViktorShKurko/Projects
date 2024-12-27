namespace Domain.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public required string FirstName { get; set; }// 2 < value < 20

        /// <summary>
        /// Фамилия.
        /// </summary>
        public required string LastName { get; set; } // 2 < value < 20

        /// <summary>
        /// Отчество.
        /// </summary>
        public required string MiddleName { get; set; } // 2 < value < 20

        /// <summary>
        /// Почта.
        /// </summary>
        public required string Email { get; set; } // val > 2 @.com|mail|bk|yandex|google| .ru | ......

        /// <summary>
        /// Навигационое свойство.Заказы.
        /// </summary>
        public ICollection<Order>? Orders { get; set; }
    }
}
