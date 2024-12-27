using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;
using WorkTask.Application.Order.Repositories;
using WorkTask.AppServices.Product.Repositories;
using WorkTask.AppServices.User.Repositories;

namespace WorkTask.Application.Order.Services
{
    /// <inheritdoc/>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository,IProductRepository productRepository , IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<long> CreateOrUpdateAsync(OrderModel order, CancellationToken cancellationToken)
        {
            order.User = await GeExistDataIfUserExist(order.User);
            order.Products = (ProductModel[]?)await ProductsValidationsAsync(order.Products);


            return await _orderRepository.AddAsync(order);
        }

        private async Task<ICollection<ProductModel>> ProductsValidationsAsync(ICollection<ProductModel> products) 
        {
            //
            foreach (var productDto in products)
            {
                var productId = await _productRepository.GetProductIdByName(productDto.Name); //TPO
                if (productId != 0) 
                {
                    productDto.Id = productId.Value;
                }
            }

            return products;
        }

        private async Task<UserModel> GeExistDataIfUserExist(UserModel user) 
        {
            user.Id = await _userRepository.GetIdByMail(user.Email);
            return user;
        }

        public async Task<bool> CreateOrdersAsync(ICollection<OrderModel> orders)
        {
            var users = orders.Select(u => u.User).ToList();

            await _userRepository.AddRangeAsync(users);

            var products = orders.SelectMany(p => p.Products).ToList();

            await _productRepository.AddRangeAsync(products);

            await _orderRepository.AddRangeAsync(orders);
            return true;
        }


        public async Task<OrderModel> GetByIdAsync(long id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

    }
}
