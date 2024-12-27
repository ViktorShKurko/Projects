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
using WorkTask.DataAccess.Mappers;

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
            Product newProduct = ProductMapper.ToProduct(product);

            await _repository.AddAsync(newProduct,new CancellationToken());

            return newProduct.Id;
        }

        public async Task UpdateAsync(ProductModel product)
        {
            var isExist = _repository.GetAll().Any(x => x.Id == product.Id);

            if (isExist)
            {
                var productDomain = ProductMapper.ToProduct(product);
                await _repository.UpdateAsync(productDomain, new CancellationToken());
            }
        }

        public async Task DeleteAsync(int id)
        {
            var isExist = _repository.GetAll().Any(x=> x.Id == id);

            if (isExist)
               await _repository.DeleteAsync(id, new CancellationToken());
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            ProductModel productDto = null;
            var product = await _repository.GetByIdAsync(id, new CancellationToken());
            if (product != null)
            {
                productDto = ProductMapper.ToProductDto(product);
            }

            return productDto;
        }

        public async Task<long?> GetProductIdByName(string name)
        {
            return await _repository.GetAll().Where(p=> p.Name.ToLower() == name.ToLower()).Select(x=> x.Id).FirstOrDefaultAsync();
        }

        public async Task AddRangeAsync(ICollection<ProductModel> productsDto)
        {
            var productDisctincts = productsDto.GroupBy(x => x.Name).ToList();
            var existing = _repository.GetAll().Where(x => productDisctincts.Select(n=> n.Key).Contains(x.Name)).Select(x => new { x.Id, x.Name }).ToList();
            var newProductsDto = productDisctincts.Where(x => !existing.Any(e => e.Name == x.Key)).Select(x=> x.FirstOrDefault()).ToList();
            var products = MapProductsList(newProductsDto);

            await _repository.AddRangeAsync(products);

            var productsIds = existing.Concat(products.Select(x => new { x.Id, x.Name }).ToList());
            foreach (var product in productsDto)
            {
                var productId = productsIds.FirstOrDefault(x => x.Name == product.Name);
                product.Id = productId.Id;
            }
        }

        private ICollection<Product> MapProductsList(ICollection<ProductModel> productsDto)
        {
            var products = new List<Product>();
            foreach (var product in productsDto)
            {
                products.Add(ProductMapper.ToProduct(product));
            }

            return products;
        }
    }
}
