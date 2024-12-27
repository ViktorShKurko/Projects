using Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestWorkTask.Models;

namespace WorkTask.DataAccess.Mappers
{
    internal class ProductMapper
    {
        public static Product ToProduct(ProductModel productDto, Product attachProduct = null) 
        {
            Product product = attachProduct ?? new Product() { Name = "" };
            product.Id = productDto.Id;
            product.Name = productDto.Name;
            product.Price = productDto.Price;

            return product;
        }

        public static ProductModel ToProductDto(Product product) 
        {
            return new ProductModel 
            { 
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        }

        public static List<ProductModel> ToProductDtoList(ICollection<Product> products) 
        {
            var result = new List<ProductModel>();
            foreach (var product in products)
            {
                result.Add(ToProductDto(product));
            }

            return result;
        }
    }
}
