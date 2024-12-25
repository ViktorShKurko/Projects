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

        public async Task<long> CreateAsync(OrderModel order, CancellationToken cancellationToken)
        {
            order.User = await UserValidationsAsync(order.User);
            order.Products = (ProductModel[]?)await ProductsValidationsAsync(order.Products);
            return await _orderRepository.AddAsync(order);
        }

        private async Task<ICollection<ProductModel>> ProductsValidationsAsync(ICollection<ProductModel> products) 
        {
            foreach (var productDto in products)
            {
                var productId = await _productRepository.GetProductIdByName(productDto.Name);
                if (productId != null && productId != 0) 
                {
                    productDto.Id = productId.Value;
                }
            }

            return products;
        }

        private async Task<UserModel> UserValidationsAsync(UserModel user) 
        {
            var userId = await _userRepository.GetIdByMail(user.Email);
            if (userId != null && userId != 0) 
            {
                user.Id = userId.Value;
            }

            return user;
        }

        public async Task<OrderModel> GetByIdAsync(long id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }
    }
}
