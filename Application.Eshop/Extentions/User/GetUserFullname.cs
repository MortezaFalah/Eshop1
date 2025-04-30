using Application.Eshop.Services.Impelimentation;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Extentions.User
{
    public static class GetUserFullname
    {
        public static string GetFullname(this Domain.Eshop.Models.User.User? user)
        {
            return $"{user?.Firstname} {user?.Lastname}";
        }

        public static async Task<string> GetFullNameAsync(this Domain.Eshop.Models.User.User? user, IUserService userService)
        {
            Domain.Eshop.Models.User.User? usr = await userService.GetUserById(user.Id);

            if (user == null) return string.Empty;

            return $"{user.Firstname} {user.Lastname}".Trim();
        }
    }
}
