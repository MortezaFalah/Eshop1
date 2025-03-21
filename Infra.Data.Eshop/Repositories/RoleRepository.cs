using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.User;
using Domain.Eshop.ViewModels.Permission;
using Domain.Eshop.ViewModels.Role;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class RoleRepository
        (EshopContext _context)
        : IRoleRepository
    {
        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }


        public async Task<List<int>> GetRoleIdsAsync(int userid)
        {
            return await _context.UserRole.Where(f => f.UserId == userid).Select(v => v.RoleId).ToListAsync();
        }

        public async Task<int> InsertAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role.Id;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
        }



        public async Task<List<Permission>> GetAllPermissionsAsync()
          => await _context.Permissions.ToListAsync();

        public async Task InsertPermissionForRoleAsync(PermissionRole rolePermission)
          => await _context.AddAsync(rolePermission);

        public async Task<UpdateRoleViewModel?> GetForUpdateAsync(int? roleId)
            => await _context.Roles.Where(e => e.Id == roleId).Include(r => r.PermissionRole)
            .Select(v => new UpdateRoleViewModel()
            {
                RoleTitle = v.RoleTitle,
                RoleId = v.Id,
                CreateDate = v.CreateDate,
                SelectedPermission = v.PermissionRole.Select(f => f.PermissionId).ToList(),
                
            }).FirstOrDefaultAsync();

        public async Task<bool> DeleteRolePermissionAsync(int roleid)
        {
            var PermissionToRemove = await _context.PermissionRoles.Where(g => g.RoleId == roleid).ToListAsync();
            if (PermissionToRemove != null)
            {
                _context.RemoveRange(PermissionToRemove);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public void DeleteAsync(Role role)
          => _context.Roles.Remove(role);

        public async Task<Role?> GetByIdAsync(int id)
          => await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);

        #region MethodForPermission

        public List<Role?> GetAllRolesHasThisPermission(string permissionname)
        {
            int permissionid = GetPermissionIdFromTitle(permissionname);
            return _context.PermissionRoles.Where(d => d.PermissionId == permissionid).Select(q => q.Role).ToList();
        }

        public List<Role?> GetAllRolesForThisUser(int userid)
        {
            return _context.UserRole.Where(w => w.UserId == userid).Select(c => c.Role).ToList();
        }

        public int GetPermissionIdFromTitle(string permissionname)
        {
            return _context.Permissions.FirstOrDefault(t => t.PermissionTitle == permissionname).PermissionId;
        }

        #endregion
    }
}
