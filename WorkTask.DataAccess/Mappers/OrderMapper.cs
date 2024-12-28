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
        /// <summary>
        /// Мапит из OrderModel в Order
        /// </summary>
        /// <param name="orderDto">обьект полученных данных заказа Dto</param>
        /// <param name="attachOrder">Обьект данных из базы.Который трэкается EF(проверяется на изменения)</param>
        /// <returns></returns>
        public static Order ToOrder(OrderModel orderDto, Order attachOrder = null) 
        {
            var userDto = orderDto.User;
            var order = attachOrder ?? new Order();
            order.Id = orderDto.Id;
            order.Reistered = Convert.ToDateTime(orderDto.CreatAt);
            order.Products = ToOrderProductList(orderDto.Products, order.Products?.ToList());
            order.Sum = orderDto.Sum;
            order.UserId = userDto.Id;
            order.User = userDto.Id != 0 ? null : UserMapper.ToUser(orderDto.User);


            return order;
        }

        /// <summary>
        /// Мап листа OrderModel(Dto) в лист Order(доменая сущность)
        /// </summary>
        /// <param name="ordersDto">Лист обьектов полученных заказов Dto</param>
        /// <param name="attachOrders">Лист обьектов Order отслеживаемых EF</param>
        /// <returns>Лист обьектов Order с данными из OrderModel</returns>
        public static List<Order> ToOrdersList(IEnumerable<OrderModel> ordersDto, ICollection<Order> attachOrders = null) 
        {
            var orders = attachOrders ?? new List<Order>();
            foreach (var orderDto in ordersDto) 
            {
                orders.Add(ToOrder(orderDto, attachOrders?.FirstOrDefault(x=> x.Id == orderDto.Id)));
            }

            return orders.ToList();
        }

        /// <summary>
        /// Мап ProductModel в OrderProduct
        /// </summary>
        /// <param name="productDto">Полученые данные товара</param>
        /// <param name="attachdOrderProduct">Отслеживаемый обьект товара из БД</param>
        /// <returns>OrderProduct с данными из ProductModel</returns>
        public static OrderProduct ToOrderProduct(ProductModel productDto, OrderProduct attachdOrderProduct = null) 
        {
            OrderProduct orderProduct = attachdOrderProduct ?? new OrderProduct();
            orderProduct.ProductId = productDto.Id;
            orderProduct.Quantity = productDto.Quantity;
            orderProduct.Product = productDto.Id == 0 ? ProductMapper.ToProduct(productDto, orderProduct.Product) : null;

            return orderProduct;
        }

        /// <summary>
        /// Мап листа ProductModel в лист OrderProduct
        /// </summary>
        /// <param name="productDtos">Лист полученных данных о товарах</param>
        /// <param name="products">Лист отслеживаемых обьектов их БД</param>
        /// <returns></returns>
        public static List<OrderProduct> ToOrderProductList(IEnumerable<ProductModel> productDtos, List<OrderProduct> products = null) 
        {
            var result = products ?? new List<OrderProduct>();
            result.Clear();

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
                }
            };

            var products = order.Products.Select(x => x.Product).ToList();
            orderDto.Products = ProductMapper.ToProductDtoList(order.Products.Select(x => x.Product).ToArray()).ToArray();
            return orderDto;
        }
    }
}
