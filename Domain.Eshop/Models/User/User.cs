using Domain.Eshop.Models.Common;
using Domain.Eshop.Models.Enums;
using Domain.Eshop.Models.Product;
using Domain.Eshop.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.User
{
    public class User : BaseEntity<int>
    {
     
        [Display(Name ="نام")]
     
        [MaxLength(50, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? Firstname { get; set; }
        [Display(Name = "نام خانوادگی")]
        [MaxLength(80, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? Lastname { get; set; }
        [MaxLength(15, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name ="شماره موبایل")]
        public string Mobile { get; set; }
        [Display(Name = "ایمیل")]
        [MaxLength(150, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [EmailAddress(ErrorMessage ="فرمت ورودی {0} درست نمیباشد")]
        public string? email { get; set; }
        [Display (Name ="رمز عبور")]
        [MaxLength(100, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "کد تایید")]
        [MaxLength(100, ErrorMessage = "{0} حداکثر میتواند 12 کرکتر باشد")]
        public int? ConfirmCode { get; set; }

        [Display(Name = "وضعیت")]
        public UserStatus Status { get; set; }
        [MaxLength(40)]
        public string? AvatarName { get; set; }

        public bool IsDelete { get; set; } = false;


        public List<UserRole>? UserRole { get; set; }

        public ICollection<Domain.Eshop.Models.Order.Order>? Order { get; set; }

        public ICollection<ProductComment>? ProductComment { get; set; }
    }
}
