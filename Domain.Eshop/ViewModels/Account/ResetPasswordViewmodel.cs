using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Account
{
    public class ResetPasswordViewmodel
    {


        #region Peroperties


        public int? UserId { get; set; }

       
        public string? Mobile { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(25, ErrorMessage = "کلمه عبور حداکثر میتواند 25 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا پسورد را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [MaxLength(25, ErrorMessage = "کلمه عبور حداکثر میتواند 25 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا تکرار پسورد را وارد کنید")]
        [Compare(nameof(Password), ErrorMessage = "تکرار کلمه عبور با خود کلمه عبور مغایرت دارد")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "کد تایید")]
        [Required(ErrorMessage = "لطفا کد تایید را وارد کنید")]
       
        public int ConfirmCode { get; set; }


        #endregion
    }
    public enum Resetpasswordresult
    {
        success,
        NotFound,
        error,
    }
}
