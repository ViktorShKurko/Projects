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
        Task<long> AddAsync(OrderModel model);
    }
}
                                                                                                                                            