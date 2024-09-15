using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Account
{
    public class RegisterViewModel
    {

        #region Peroperties
        [Display(Name = "موبایل")]
        [MaxLength(15, ErrorMessage = "شماره موبایل ورودی معتبر نمیباشد")]
        [Required(ErrorMessage = "لطفا شماره موبایل را وارد کنید")]
        public string Mobile { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(25, ErrorMessage = "کلمه عبور حداکثر میتواند 25 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا پسورد را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(25, ErrorMessage = "کلمه عبور حداکثر میتواند 25 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا تکرار پسورد را وارد کنید")]
        [Compare(nameof(Password), ErrorMessage = "تکرار کلمه عبور با خود کلمه عبور مغایرت دارد")]
        public string ConfirmPassword { get; set; }
        #endregion

    }

    public enum RegisterResult
    {
        SuccessRegister,
        Error,
        DuplicatedMobile
    }
}
