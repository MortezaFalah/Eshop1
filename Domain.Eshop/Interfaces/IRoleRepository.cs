using Domain.Eshop.Models.User;
using Domain.Eshop.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();

        Task<int> InsertAsync(Role role);

        void UpdateRole(Role role);

        Task SaveAsync();

        Task<List<int>> GetRoleIdsAsync(int userid);

        Task<List<Permission>> GetAllPermissionsAsync();


        Task InsertPermissionForRoleAsync(PermissionRole rolePermission);

        Task<bool> DeleteRolePermissionAsync(int roleid);

        Task<UpdateRoleViewModel?> GetForUpdateAsync(int? roleId);

        void DeleteAsync(Role role); 

        Task<Role?> GetByIdAsync(int id);


        List<Role?> GetAllRolesHasThisPermission(string permissionname);


        List<Role?> GetAllRolesForThisUser(int userid);

        int GetPermissionIdFromTitle(string permissionname);

       
    }
}
