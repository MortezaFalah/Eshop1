using Domain.Eshop.Models.User;
using Domain.Eshop.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByMobileAsync(string mobile);

        Task<EditProfileViewModel?> GetUserforEditProfile(int userid);


        //void UpdateProfileUser(EditProfileViewModel model);


        Task<EditProfileResult> UpdateUserAsync(EditProfileViewModel model);

      
        
    }
}
