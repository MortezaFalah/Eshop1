using Domain.Eshop.Enums;
using Domain.Eshop.Models.Common;
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

        [MaxLength(50, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? Firstname { get; set; }
        [MaxLength(80, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? Lastname { get; set; }
        [MaxLength(15, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name ="شماره موبایل")]
        public string Mobile { get; set; }
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

        public UserStatus Status { get; set; }

    }
}
