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
            var names = model.User.FullName.Split(' ');
            var order = new Order
            {
                InnerId = model.Id,
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
                    Product =  new Product {  Name = product.Name, Price = product.Price }
                });
            }

            return await _repository.AddAsync(order, new CancellationToken());
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id,new CancellationToken());
        }

        public async Task<OrderModel> GetByInnerId(long id)
        {
           var order = await _repository.GetAll().FirstOrDefaultAsync(x => x.InnerId == id);
           var user = order.User;
           var orderdto = new OrderModel 
           {
               Id = id,
               Sum = order.Sum,
               CreatAt = order.Reistered.ToString(),
               User = new UserModel { Email = user.Email, FullName = $"{user.LastName} {user.FirstName} {user.MiddleName}"},
               //Products = order.Products.ToArray(),
           };

           return orderdto;
        }

        public Task UpdateAsync(OrderModel model)
        {
            throw new NotImplementedException();
        }
    }
}
