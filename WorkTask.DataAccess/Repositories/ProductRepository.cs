using Domain.Models;
using Infrastucture;
using Microsoft.EntityFrameworkCore;
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

        public async Task<long> AddAsync(ProductModel product)
        {
            Product newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
            };

            await _repository.AddAsync(newProduct,new CancellationToken());

            return newProduct.Id;
        }
        public Task UpdateAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var isExist = _repository.GetAll().Any(x=> x.Id == id);

            if (isExist)
               await _repository.DeleteAsync(id, new CancellationToken());
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            ProductModel? productDto = null;
            var product = await _repository.GetByIdAsync(id, new CancellationToken());
            if (product != null)
            {
                productDto = new ProductModel 
                { 
                    Id = id,
                    Name = product.Name,
                    Price = product.Price,

                };
            }

            return productDto;
        }

        public async Task<long?> GetProductIdByName(string name)
        {
            return await _repository.GetAll().Where(p=> p.Name.ToLower() == name.ToLower()).Select(x=> x.Id).FirstOrDefaultAsync();
        }

    }
}
