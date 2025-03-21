using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.User;
using Domain.Eshop.ViewModels.Permission;
using Domain.Eshop.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class RoleService 
        (IRoleRepository rolerepository): IRoleService
    {
       

        public async Task<List<Role>> GetAllAsync()
        {
           return await rolerepository.GetAllAsync();
        }


        public async Task<CreateRoleViewModel> GetPermissionForCreateRoleAsync()
        {
            List<Permission> permissions = await rolerepository.GetAllPermissionsAsync();
            CreateRoleViewModel viewModel = new()
            {
                Permissions = permissions.Select(r => new PermissionViewModel(){
                    PermissionTitle = r.PermissionTitle,
                    PermissionId = r.PermissionId,
                    ParentId = r.ParentId

                }).ToList()
            };

            return viewModel;
        }


        public async Task<CreateRoleResult> CreateRoleAndPermissionRoleAsync(CreateRoleViewModel model)
        {
           if(model == null) { return CreateRoleResult.PermissionNotFound; }

            Role role = new()
            {
                RoleTitle = model.RoleTitle,
                CreateDate = DateTime.Now,
                
            };
            int roleid = await rolerepository.InsertAsync(role);

            foreach(var permission in model.SelectedPermission)
            {
                PermissionRole permissionRole = new()
                {
                    RoleId = roleid,
                    PermissionId = permission,
                };
                await rolerepository.InsertPermissionForRoleAsync(permissionRole);
                await rolerepository.SaveAsync();
            }
            return CreateRoleResult.Success;
        }

        public async Task<UpdateRoleViewModel?> GetForUpdateAsync(int? roleid)
        {
            if(roleid == null ) { return null; }

            var prm = await rolerepository.GetAllPermissionsAsync();
            UpdateRoleViewModel viewModel = await rolerepository.GetForUpdateAsync(roleid);

            viewModel.Permissions = prm.Select(r => new PermissionViewModel()
            {
                PermissionTitle = r.PermissionTitle,
                ParentId = r.ParentId,
                PermissionId = r.PermissionId,
            }).ToList();
            return viewModel;
        }

        public async Task<UpdateRoleResult> UpdateRoleAndPermissionAsync(UpdateRoleViewModel? updateRoleViewModel)
        {
            if(updateRoleViewModel == null) { return UpdateRoleResult.RoleNotFound; }
            if (updateRoleViewModel.SelectedPermission != null)
            {
                await rolerepository.DeleteRolePermissionAsync(updateRoleViewModel.RoleId);
                foreach(var item in updateRoleViewModel.SelectedPermission)
                {
                    PermissionRole permissionRole = new()
                    {
                        PermissionId = item,
                        RoleId = updateRoleViewModel.RoleId
                    };
                    await rolerepository.InsertPermissionForRoleAsync(permissionRole);
                }
            }
            else
            {
                await rolerepository.DeleteRolePermissionAsync(updateRoleViewModel.RoleId);
            }
            Role role = new()
            {
                RoleTitle = updateRoleViewModel.RoleTitle,
                Id =updateRoleViewModel.RoleId,  
                CreateDate = updateRoleViewModel.CreateDate,
                
            };
            rolerepository.UpdateRole(role);
            await rolerepository.SaveAsync();
            return UpdateRoleResult.Success;
        }

        public async Task<DeleteRoleResult> ConfirmDelete(int roleid)
        {
            Role? role = await rolerepository.GetByIdAsync(roleid);
            if(role == null) { return DeleteRoleResult.RoleNotFound; }

            await rolerepository.DeleteRolePermissionAsync(roleid);

            rolerepository.DeleteAsync(role);
            await rolerepository.SaveAsync();
            return DeleteRoleResult.Success;
         

        }
    }
}
