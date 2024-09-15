using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.User
{
    public class EditProfileViewModel
    {

        public int? UserId { get; set; }
        [Display(Name = "نام")]
        [MaxLength(25, ErrorMessage = "کلمه عبور حداکثر میتواند 25 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا پسورد را وارد کنید")]

        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        [MaxLength(25, ErrorMessage = "{0} حداکثر میتواند 25 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا پسورد را وارد کنید")]
        public string LastName { get; set; }
        [Display(Name = "ایمیل")]
        [MaxLength(40, ErrorMessage = "{0} حداکثر میتواند 40 کرکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage ="فرمت ورودی ایمیل درست نمیباشد")]
        public string Email { get; set; }


    }

    public enum EditProfileResult
    {
        success,
        error,
        NotFound,
    }
}
