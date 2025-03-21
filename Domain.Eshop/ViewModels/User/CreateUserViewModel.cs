using Domain.Eshop.Models.Enums;
using Domain.Eshop.Models.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.User
{
    public class CreateUserViewModel
    {
        
        [Display(Name = "نام")]

        [MaxLength(50, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? Firstname { get; set; }
        [Display(Name = "نام خانوادگی")]
        [MaxLength(80, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? Lastname { get; set; }
        [MaxLength(15, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "شماره موبایل")]
        public string Mobile { get; set; }
        [Display(Name = "ایمیل")]
        [MaxLength(150, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [EmailAddress(ErrorMessage = "فرمت ورودی {0} درست نمیباشد")]
        public string? email { get; set; }
        [Display(Name = "رمز عبور")]
        [MaxLength(100, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        [MaxLength(40)]
        public string? AvatarName { get; set; }

        public bool IsDelete { get; set; } = false;


        public List<int> RoleIds { get; set; } = new List<int>();

        public IFormFile? AvatarFile { get; set; }



    }

    public enum CreateUserViewModelResult
    {
        Success,
        NotSelectedRoles,
        Error,
        DupplicatedMobile,
    }
}
