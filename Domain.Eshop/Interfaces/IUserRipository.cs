using Domain.Eshop.Models.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IUserRipository
    {
    
        Task<bool> ExistMobileAsync(string mobile);

        Task InsertAsync(User user);


        Task SaveAsync();


        Task<User> GetByIdMobilePassword(string mobile, string password);

        Task<User?> GetByMobileAsync(string mobile);

        Task<User?> GetByMobileandConfirmCode(string mobile, int confirmCode);

        void UpdateUser(User user);

        Task<User?> GetUserById(int userid);

    
    }
}
