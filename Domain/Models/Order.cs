using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Order
    {
        public  long Id { get; set; }
        public long InnerId { get; set; }
        public required DateTime Reistered { get; set; }
        public decimal Sum { get; set; } // > 0
        public long UserId { get; set; }
        public User? User { get; set; }
        public required ICollection<OrderProduct> Products { get; set; }
    }

    public class OrderProduct 
    {
        public long OrderId { get; set; }
        public Order? Order { get; set; }
        public long ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; } // > 0
    }
}
