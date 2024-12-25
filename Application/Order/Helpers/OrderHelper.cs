using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;
using WorkTask.Application.Order.Services;
using WorkTask.AppServices.Product.Services;
using WorkTask.AppServices.User.Services;

namespace WorkTask.AppServices.Order.Helpers
{
    public class OrderHelper : IOrderHelper
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public OrderHelper(IOrderService orderService, IProductService productService, IUserService userService) 
        {
            _orderService = orderService;
            _productService = productService;
            _userService = userService;
        }

        public Task CreateOrUpdate(OrderModel order)
        {
            // var existOrder = 

            return null;
        }

        public Task CreateOrUpdate(OrdersModel orders)
        {
            throw new NotImplementedException();
        }

        public Task Delete(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public Task Delete(OrdersModel orders)
        {
            throw new NotImplementedException();
        }
    }
}
