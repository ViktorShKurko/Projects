using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestWorkTask.Models;

namespace WorkTask.Application.Order.Repositories
{
    public interface IOrderRepository
    {
        //IQueryable<Order> GetAll();
        Task<long> AddAsync(OrderModel model);
        Task UpdateAsync(OrderModel model);
        Task DeleteAsync(long id);
        Task<OrderModel> GetByInnerId(long id);
    }
}
                                                                                                                                            