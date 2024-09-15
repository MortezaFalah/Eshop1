using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
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
    public class UserService(IUserRipository userRipository) : IUserService
    {
        public async Task<User?> GetByMobileAsync(string mobile)
        {
            return await userRipository.GetByMobileAsync(mobile);
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


    }
}
