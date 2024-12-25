using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;

namespace WorkTask.AppServices.Product.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Добавить товар.
        /// </summary>
        /// <param name="product">Товар.</param>
        /// <returns>Идентификатор.</returns>
        Task<long> AddAsync(ProductModel product);

        /// <summary>
        /// Обновить данные о товаре.
        /// </summary>
        /// <param name="product">Товар.</param>
        /// <returns></returns>
        Task UpdateAsync(ProductModel product);

        /// <summary>
        /// Удалить товар.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Получить товар по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Товар.</returns>
        Task<ProductModel>GetProductByIdAsync(int id);

        /// <summary>
        /// Получить товар по наименованию.
        /// </summary>
        /// <param name="name">Наименование товара.</param>
        /// <returns>Товар.</returns>
        Task<long?> GetProductIdByName(string name);

    }
}
