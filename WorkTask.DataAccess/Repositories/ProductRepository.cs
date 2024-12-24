using Domain.Models;
using Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;
using WorkTask.AppServices.Product.Repositories;

namespace WorkTask.DataAccess.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly IRepository<Product, WorkTaskDbContext> _repository;

        public ProductRepository(IRepository<Product, WorkTaskDbContext> repository)
        {
            _repository = repository;
        }

        public Task<long> AddAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
