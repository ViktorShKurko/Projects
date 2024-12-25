using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWorkTask.Models;

namespace WorkTask.AppServices.User.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Возвращает пользователя.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        Task<UserModel> GetByIdAsync(int id);

        /// <summary>
        /// Получить идентификатор пользователя по email.
        /// </summary>
        /// <param name="mail">Email пользователя.</param>
        /// <returns></returns>
        Task<long?> GetIdByMail(string mail);
    }
}
