using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Account
{
    public class LoginViewModel
    {


        [Display(Name = "شماره موبایل")]
        [MaxLength(15, ErrorMessage = "شماره موبایل حداکثر میتواند 15 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا شماره موبایل را وارد کنید")]
        public string Mobile { get; set; }


        [Display(Name = "کلمه عبور")]
        [MaxLength(25, ErrorMessage = "کلمه عبور حداکثر میتواند 25 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا پسورد را وارد کنید")]
        public string Password { get; set; }


    }

    public enum LoginResult
    {
        Successfully,
        IsBan,
        NotFound,
        WrongItem
    }
}
