using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.User;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class UserRipository(EshopContext _context) : IUserRipository
    {
        #region User
        public async Task<bool> ExistMobileAsync(string mobile)
        {
            return await _context.Users.AnyAsync(u => u.Mobile == mobile);
        }

        public async Task<User?> GetByIdMobilePassword(string mobile, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(o => o.Mobile == mobile && o.Password == password);
        }

        public async Task<User?> GetByMobileandConfirmCode(string mobile, int confirmCode)
       => await _context.Users.FirstOrDefaultAsync(i=>i.Mobile==mobile && i.ConfirmCode == confirmCode);

        public async Task<User?> GetByMobileAsync(string mobile)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Mobile == mobile);
        }

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }


        public void UpdateUser(User user)
        {
            _context.Users.Update(user);

        }


        #endregion

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserById(int userid)
        {
            return await _context.Users.FirstOrDefaultAsync(r=>r.Id == userid);
        }
    }
}
