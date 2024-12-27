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

        public async Task AddRangeAsync(ICollection<UserModel> usersDtos)
        {
            var userDisctincts = usersDtos.GroupBy(x=> x.Email);
            var existing = _repository.GetAll().Where(x => userDisctincts.Select(e=> e.Key).Contains(x.Email)).Select(x=> new { x.Id, x.Email }).ToList();
            var newUsersDto = userDisctincts.Where(x => !existing.Any(e => e.Email == x.Key)).Select(x=> x.FirstOrDefault()).ToList();
            var newUsers = MapUserList(newUsersDto);

            await _repository.AddRangeAsync(newUsers);

            var allUsersData = existing.Concat(newUsers.Select(x => new { x.Id, x.Email }));

            foreach (var userDto in usersDtos)
            {
                var user = allUsersData.FirstOrDefault(x=> x.Email == userDto.Email);
                userDto.Id = user.Id;
            }
        }

        private ICollection<User> MapUserList(ICollection<UserModel> usersDto) 
        {
            var users = new List<User>();
            foreach (var userDto in usersDto)
            {
                users.Add(MapUser(userDto));
            }

            return users;
        }

        private User MapUser(UserModel userDto) 
        {
            string[] names = userDto.FullName.Split(' ');
            return new User 
            { 
                Email = userDto.Email,
                FirstName = names[1], 
                LastName = names[0], 
                MiddleName = names[2], Id = userDto.Id
            };
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

        public async Task<long> GetIdByMail(string mail)
        {
            return await _repository.GetAll().Where(u=> u.Email.ToLower() == mail.ToLower()).Select(u => u.Id).FirstOrDefaultAsync();
        }
    }
}
