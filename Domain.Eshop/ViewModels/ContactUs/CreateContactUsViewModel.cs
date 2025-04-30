using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.ContactUs
{
    public class CreateContactUsViewModel
    {
        [Display(Name ="موضوع")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید ")]
        [MaxLength(80,ErrorMessage ="تعداد کرکتر وارد شده بیشتر از حد مجاز میباشد")]
        public string Title { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(40, ErrorMessage = "تعداد کرکتر وارد شده بیشتر از حد مجاز میباشد")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(50, ErrorMessage = "تعداد کرکتر وارد شده بیشتر از حد مجاز میباشد")]
        public string Email { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(15, ErrorMessage = "تعداد کرکتر وارد شده بیشتر از حد مجاز میباشد")]
        public string Mobile { get; set; }

        [Display(Name = " توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید ")]
        [MaxLength(800, ErrorMessage = "تعداد کرکتر وارد شده بیشتر از حد مجاز میباشد")]
        public string Description { get; set; }

        public string? Ip { get; set; }



    }
}
