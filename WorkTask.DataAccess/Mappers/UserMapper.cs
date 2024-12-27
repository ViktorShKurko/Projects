using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;

namespace WorkTask.DataAccess.Mappers
{
    internal class UserMapper
    {
        public static User ToUser(UserModel userDto) 
        {
            var names = userDto.FullName.Split(' ');
            return new User 
            { 
                Id = userDto.Id, 
                Email = userDto.Email,
                FirstName = names[1],
                LastName = names[0],
                MiddleName = names[2]
            };
        }
    }
}
