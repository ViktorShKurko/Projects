using Domain.Models;
using Infrastucture;
using Microsoft.EntityFrameworkCore;
using TestWorkTask.Models;
using WorkTask.Application.Order.Repositories;


namespace WorkTask.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IRepository<Order, WorkTaskDbContext> _repository;

        public OrderRepository(IRepository<Order, WorkTaskDbContext> repository)
        {
            _repository = repository;
        }

        public async Task<long> AddAsync(OrderModel model)
        {
            Order order = await _repository.GetByIdAsync(model.Id, new CancellationToken());

            if (order == null)
            {
                var names = model.User.FullName.Split(' '); // TODO Validation models fio, mail in Application layer
                order = new Order
                {
                    Id = model.Id,
                    Reistered = Convert.ToDateTime(model.CreatAt),
                    Products = new List<OrderProduct>(),
                    Sum = model.Sum,
                    User = new User
                    {
                        Email = model.User.Email,
                        FirstName = names[1],
                        LastName = names[0],
                        MiddleName = names[2]
                    }
                };

                foreach (var product in model.Products)
                {
                    order.Products.Add(new OrderProduct
                    {
                        Quantity = product.Quantity,
                        Product = new Product { Name = product.Name, Price = product.Price }
                    });
                }

                await _repository.AddAsync(order, new CancellationToken());
            }

            return model.Id;
        }


        public async Task<OrderModel> GetByIdAsync(long id)
        {
            var order = await _repository.GetByIdAsync(id, new CancellationToken());
            OrderModel orderModel = null;
            if (order == null) 
            {
                
            }

            return orderModel;
        }

        public async Task UpdateAsync(OrderModel model)
        {
            var order = await _repository.GetByIdAsync(model.Id, new CancellationToken());
            if (order == null) 
            {
               // await _repository.UpdateAsync() // To order
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
    }
}
