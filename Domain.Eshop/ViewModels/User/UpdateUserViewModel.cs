using Domain.Eshop.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.User
{
    public class UpdateUserViewModel
    {
        public int Userid { get; set; }
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



        [MaxLength(40)]
        public string? AvatarName { get; set; }
        [Display(Name ="وضعیت کاربر")]
        public UserStatus Status { get; set; }

        [Display(Name ="نقش های کاربر")]
        public List<int> RoleIds { get; set; } = new List<int>();

        public IFormFile? AvatarFile { get; set; }



    }

    public enum UpdateUserViewModelResult
    {
        Success,
        NotSelectedRoles,
        NotFound,
        DupplicatedMobile
       
    }
}

