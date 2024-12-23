using Domain.Models;
using Infrastucture;
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
            var names = model.User.FullName.Split(' ');
            var order = new Order
            {
                //Id = model.Id,
                Reistered = Convert.ToDateTime(model.CreatAt),
                Products = new List<OrderProduct>(),
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

            return await _repository.AddAsync(order, new CancellationToken());
        }
    }
}
