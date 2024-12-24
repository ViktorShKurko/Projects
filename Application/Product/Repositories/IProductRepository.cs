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
        Task<ProductModel>GetProductByIdAsync(int id);
        Task<long> AddAsync(ProductModel product);
        Task UpdateAsync(ProductModel product);
        Task DeleteAsync(int id);
    }
}
