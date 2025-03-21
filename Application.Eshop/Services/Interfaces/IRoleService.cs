using Domain.Eshop.Models.User;
using Domain.Eshop.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
     public interface IRoleService
    {

       Task<List<Role>> GetAllAsync();

        Task<CreateRoleViewModel> GetPermissionForCreateRoleAsync();

        Task<CreateRoleResult> CreateRoleAndPermissionRoleAsync(CreateRoleViewModel model);

        Task<UpdateRoleViewModel?> GetForUpdateAsync(int? roleid);

        Task<UpdateRoleResult> UpdateRoleAndPermissionAsync(UpdateRoleViewModel? updateRoleViewModel);

        Task<DeleteRoleResult> ConfirmDelete(int roleid);
    }
}
