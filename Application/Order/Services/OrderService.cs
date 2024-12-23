using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;
using WorkTask.Application.Order.Repositories;

namespace WorkTask.Application.Order.Services
{
    /// <inheritdoc/>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<long> CreateAsync(OrderModel order, CancellationToken cancellationToken)
        {
            return await _orderRepository.AddAsync(order);
        }
    }
}
