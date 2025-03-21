using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.User;
using Domain.Eshop.ViewModels.User;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class UserRoleRepository
       (EshopContext _context) : IUserRoleRepository
    {
        public async Task<List<int>> GetUserRoleIdsAsync(int userid)
        {

            return _context.UserRole.Where(f => f.UserId == userid).Select(v => v.Id).ToList();
        }

        public async void InsertAsync(List<int> roleid, int userid)
        {
            foreach (var item in roleid)
            {
                _context.UserRole.Add(new UserRole
                {
                    UserId = userid,
                    RoleId = item

                });

            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(List<int> roleid, int userid)
        {
            List<UserRole> userrole = _context.UserRole.Where(f => f.UserId == userid).ToList();
            foreach (var role in userrole) { _context.UserRole.Remove(role); }
            foreach (var item in roleid)
            {
                _context.UserRole.Add(new UserRole() { RoleId = item, UserId = userid });
            }


        }


    }
}
