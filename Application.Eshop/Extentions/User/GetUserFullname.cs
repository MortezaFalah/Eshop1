using Domain.Eshop.Models.User;
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
    }
}
