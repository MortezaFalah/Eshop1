using Application.Eshop.Security;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Enums;
using Domain.Eshop.Models.User;
using Domain.Eshop.ViewModels.User;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class UserService(IUserRipository userRipository,
        IUserRoleRepository userrolerepository,
        IRoleRepository rolerepository) : IUserService
    {
        public async Task<UpdateUserViewModel> AdminSideGetForUpdateAsync(int userid)
        {
            User? user = await userRipository.GetUserById(userid);
            if (user == null) { return null; }

            UpdateUserViewModel updateUserViewModel = new UpdateUserViewModel()
            {
                Userid = userid,
                Status = user.Status,
                AvatarName = user.AvatarName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Mobile = user.Mobile,
                email = user.email,
                RoleIds = await rolerepository.GetRoleIdsAsync(userid),

            };

            return updateUserViewModel;

        }

        public async Task<UpdateUserViewModelResult> AdminSideUpdateUserAsync(UpdateUserViewModel model)
        {
            User? user = await userRipository.GetUserById(model.Userid);
            if (user == null) return UpdateUserViewModelResult.NotFound;
            if (await userRipository.ExistMobileForUpdateAsync(model.Mobile, user.Id)) return UpdateUserViewModelResult.DupplicatedMobile;
            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;
            user.Mobile = model.Mobile;
            user.Status = model.Status;
            user.email = model.email;
            if (model.RoleIds.Count == 0) { return UpdateUserViewModelResult.NotSelectedRoles; }
            userrolerepository.UpdateAsync(model.RoleIds, model.Userid);
            await userrolerepository.SaveAsync();
            if (model.AvatarFile != null)
            {
                string? lastPhoto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserAvatar", model.AvatarName ?? "");
                if (System.IO.File.Exists(lastPhoto)) { System.IO.File.Delete(lastPhoto); }
                string imagename = (Guid.NewGuid() + Path.GetExtension(model.AvatarFile.FileName).Trim()).ToString();
                string imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserAvatar", imagename);
                using (FileStream file = new FileStream(imagepath, FileMode.Create))
                {
                    model.AvatarFile.CopyTo(file);
                }
                user.AvatarName = imagename;
            }
            userRipository.UpdateUser(user);
            await userRipository.SaveAsync();
            return UpdateUserViewModelResult.Success;

        }

        public async Task<CreateUserViewModelResult> CreateUserAsync(CreateUserViewModel model)
        {

            if (await userRipository.ExistMobileAsync(model.Mobile))

                return CreateUserViewModelResult.DupplicatedMobile;


            if (model.RoleIds.Count == 0)

                return CreateUserViewModelResult.NotSelectedRoles;

            User user = new User()
            {
                CreateDate = DateTime.Now,
                Firstname = model.Firstname,
                email = model.email,
                IsDelete = false,
                Password = PasswordHelper.EncodePasswordMd5(model.Password),
                Lastname = model.Lastname,
                Mobile = model.Mobile,
                Status = UserStatus.Active,

            };
            if (model.AvatarFile != null)
            {

                string imagename = (Guid.NewGuid() + Path.GetExtension(model.AvatarFile.FileName).Trim()).ToString();
                string imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserAvatar", imagename);
                using (FileStream file = new FileStream(imagepath, FileMode.Create))
                {
                    model.AvatarFile.CopyTo(file);
                }
                user.AvatarName = imagename;
            }
            await userRipository.InsertAsync(user);
            await userRipository.SaveAsync();

            userrolerepository.InsertAsync(model.RoleIds, user.Id);
            await userRipository.SaveAsync();
            return CreateUserViewModelResult.Success;

        }

        public async Task<bool?> DeleteUserForAdminAsync(int userid)
        {
            return userid == null ? false : await userRipository.DeleteUserForAdminAsync(userid);
        }

        public async Task<User?> GetByMobileAsync(string mobile)
        {
            return await userRipository.GetByMobileAsync(mobile);
        }

        public async Task<User?> GetUserById(int userid)
        {
            return await userRipository.GetUserById(userid);
        }

        public async Task<EditProfileViewModel?> GetUserforEditProfile(int userid)
        {
            User? user = await userRipository.GetUserById(userid);
            if (user == null) { return null; }
            EditProfileViewModel edit = new EditProfileViewModel()
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Email = user.email
            };
            return edit;
        }

        public async Task<EditProfileResult> UpdateUserAsync(EditProfileViewModel model)
        {
            if (model == null) return EditProfileResult.NotFound;

            if (model.UserId != null)
            {

                User? user = await userRipository.GetUserById(model.UserId.Value);

                user.Firstname = model.FirstName;
                user.Lastname = model.LastName;
                user.email = model.Email;


                userRipository.UpdateUser(user);
                await userRipository.SaveAsync();
                return EditProfileResult.success;
            }

            return EditProfileResult.error;
        }


        public bool CheckUserHasPermission(int userid, string permissiontitle)
        {
            List<Role?> allRoles = rolerepository.GetAllRolesHasThisPermission(permissiontitle);

            List<Role?> UsrRoles = rolerepository.GetAllRolesForThisUser(userid);

            if (allRoles == null || UsrRoles == null) return false;

            foreach (var item in allRoles)
            {
                if (UsrRoles.Any(i => i.Id == item.Id))
                {
                    return true;
                }
            }


            return false;
        }

    }
}
