using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;

namespace WorkTask.DataAccess.Mappers
{
    internal class OrderMapper
    {
        public static Order ToOrder(OrderModel orderDto) 
        {
            var userDto = orderDto.User;
            var order = new Order
            {
                Id = orderDto.Id,
                Reistered = Convert.ToDateTime(orderDto.CreatAt),
                Products = ToOrderProductList(orderDto.Products),
                Sum = orderDto.Sum,
                UserId = userDto.Id,
                User = userDto.Id != 0 ? null : UserMapper.ToUser(orderDto.User),
            };

            return order;
        }

        public static OrderProduct ToOrderProduct(ProductModel productDto) 
        {
            return new OrderProduct
            {
                ProductId = productDto.Id,
                Quantity = productDto.Quantity,
                Product = productDto.Id == 0 ? ProductMapper.ToProduct(productDto) : null
            };
        }

        public static List<OrderProduct> ToOrderProductList(ICollection<ProductModel> productDtos) 
        {
            var result = new List<OrderProduct>();

            foreach (var productDto in productDtos)
            {
                result.Add(ToOrderProduct(productDto));
            }

            return result;
        }

        public static OrderModel ToOrderDto(Order order) 
        {
            var orderDto = new OrderModel
            {
                Id = order.Id,
                Sum = order.Sum,
                User = new UserModel()
                {
                    Id = order.UserId,
                    FullName = $"{order.User.LastName} {order.User.FirstName} {order.User.MiddleName}",
                    Email = order.User.Email
                },
                Products = ProductMapper.ToProductDtoList(order.Products.Select(x => x.Product).ToArray()).ToArray()
            };

            return orderDto;
        }
    }
}
