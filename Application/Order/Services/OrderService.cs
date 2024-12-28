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
            var isExist = _orderRepository.IsExist(order.Id);
            order.User = await GeExistDataIfUserExist(order.User);
            order.Products = (ProductModel[]?)await GetProductIdIfExist(order.Products);

            if (!isExist)
            {
                await _orderRepository.AddAsync(order);
            }
            else
            {
                await _orderRepository.UpdateAsync(order);
            }

            return order.Id;
        }

        /// <summary>
        /// Добавляет идентификатор товара если он есть в БД
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        private async Task<ICollection<ProductModel>> GetProductIdIfExist(ICollection<ProductModel> products) 
        {
            foreach (var productDto in products)
            {
                var productId = await _productRepository.GetProductIdByName(productDto.Name);
                if (productId != 0) 
                {
                    productDto.Id = productId.Value;
                }
            }

            return products;
        }

        /// <summary>
        ///  Добавляет идентификатор пользователя если он есть в БД
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<UserModel> GeExistDataIfUserExist(UserModel user) 
        {
            user.Id = await _userRepository.GetIdByMail(user.Email);
            return user;
        }
        
        public async Task<bool> CreateOrdersAsync(ICollection<OrderModel> orders)
        {
            //TODO: Переделать метод CreateOrdersAsync, чтоб он мог работать с дубликатами.
            var users = orders.Select(u => u.User).ToList();

            await _userRepository.AddRangeAsync(users);

            var products = orders.SelectMany(p => p.Products).ToList();

            await _productRepository.AddRangeAsync(products);

            orders = NormalisationOrdersList(orders);
            //  await _orderRepository.AddRangeAsync(orders);
            await _orderRepository.InsertOrUpdateAsync(orders);
         //   await _orderRepository.UpdateRangeAsync(orders);
            return true;
        }

        private ICollection<OrderModel> NormalisationOrdersList(ICollection<OrderModel> ordersDto) 
        {
            var orders = ordersDto.GroupBy(x => x.Id);
            var result = new List<OrderModel>();
            foreach (var order in orders)
            {
                var maxReDate = order.Max(x => Convert.ToDateTime(x.CreatAt));
                result.Add(order.FirstOrDefault(x=> Convert.ToDateTime(x.CreatAt) == maxReDate));
            }

            return result;
        }

        //1.Если есть в списке одинаковые то брать заказ с более поздей датой
        //2.Если дата одинаковая то брать один из 

        public async Task<OrderModel> GetByIdAsync(long id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

    }
}
