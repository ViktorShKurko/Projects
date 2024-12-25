using Domain.Models;
using Infrastucture;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;
using WorkTask.AppServices.User.Repositories;

namespace WorkTask.DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IRepository<User, WorkTaskDbContext> _repository;

        public UserRepository(IRepository<User,WorkTaskDbContext> repository) 
        {
            _repository = repository;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id, new CancellationToken());
            UserModel userDto = null;

            if (user != null) 
            {
                userDto = new UserModel
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName} {user.MiddleName}",
                    Email = user.Email,
                };
            }

            return userDto;
        }

        public async Task<long> GetByMail(string mail)
        {
            return await _repository.GetAll().Where(u=> u.Email.ToLower() == mail.ToLower()).Select(u => u.Id).FirstOrDefaultAsync();
        }
    }
}
