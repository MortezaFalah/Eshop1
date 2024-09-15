using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "شماره موبایل")]
        [MaxLength(15, ErrorMessage = "شماره موبایل حداکثر میتواند 15 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Mobile { get; set; }
    }

    public enum Forgotpasswordresult
    {
        Success,
        MobileNotFound,
        UserBan,
        Error
    }
}
