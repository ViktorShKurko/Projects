using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }// 2 < value < 20
        public required string LastName { get; set; } // 2 < value < 20
        public required string MiddleName { get; set; } // 2 < value < 20
        public required string Email { get; set; } // val > 2 @.com|mail|bk|yandex|google| .ru | ......
        public ICollection<Order>? Orders { get; set; }
    }
}
