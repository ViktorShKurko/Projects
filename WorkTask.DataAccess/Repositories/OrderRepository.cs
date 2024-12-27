using Domain.Models;
using Infrastucture;
using Microsoft.EntityFrameworkCore;
using TestWorkTask.Models;
using WorkTask.Application.Order.Repositories;
using WorkTask.DataAccess.Mappers;


namespace WorkTask.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IRepository<Order, WorkTaskDbContext> _repository;

        public OrderRepository(IRepository<Order, WorkTaskDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<long> AddAsync(OrderModel orderDto)
        {
            bool isExist = _repository.GetAll().Any(x => x.Id == orderDto.Id);

            if (!isExist)
            {
                await _repository.AddAsync(OrderMapper.ToOrder(orderDto), new CancellationToken());
            }

            return orderDto.Id;
        }

        public async Task<OrderModel> GetByIdAsync(long id)
        {
            var order = await _repository.GetByIdAsync(id, new CancellationToken());
            OrderModel orderDto = null;
            if (order != null) 
            {
                orderDto = OrderMapper.ToOrderDto(order);
            }

            return orderDto;
        }

        public async Task UpdateAsync(OrderModel orderDto)
        {
            var order = _repository.GetAll().FirstOrDefault(x=> x.Id == orderDto.Id);
            if (order != null) 
            {
                order = OrderMapper.ToOrder(orderDto, order);
                await _repository.UpdateAsync(OrderMapper.ToOrder(orderDto, order), new CancellationToken());
            }
        }

        public async Task DeleteAsync(long id)
        {
            var order = await _repository.GetByIdAsync(id, new CancellationToken());

            if (order != null) 
            {
               await _repository.DeleteAsync(id,new CancellationToken());
            }
        }

        public async Task AddRangeAsync(ICollection<OrderModel> orders)
        {
            var ordersIds = orders.Select(x => x.Id).ToList();
            var existing = _repository.GetAll().Where(x => ordersIds.Contains(x.Id)).Select(x => x.Id).ToList();
            var newOrders = new List<Order>();

            foreach (var orderDto in orders.Where(x => !existing.Contains(x.Id)).ToList())
            {   
                var newOrder = OrderMapper.ToOrder(orderDto);
                newOrders.Add(newOrder);
            }

            await _repository.AddRangeAsync(newOrders);
        }

        public ICollection<OrderModel> GetByIds(ICollection<long> ordesId)
        {
            var existOrders = _repository.GetAll().Where(x => ordesId.Contains(x.Id)).ToList();

            return null;
        }

        public async Task UpdateRangeAsync(ICollection<OrderModel> orderDtos)
        {
            var orders = await _repository.GetAll().Where(x => orderDtos.Select(o => o.Id).Contains(x.Id)).ToListAsync();

            orders = OrderMapper.ToOrdersList(orderDtos,orders);
            await _repository.UpdateRangeAsync(orders, new CancellationToken());
        }

        public bool IsExist(long orderId)
        {
            return _repository.GetAll().Any(x => x.Id == orderId);
        }
    }
}
