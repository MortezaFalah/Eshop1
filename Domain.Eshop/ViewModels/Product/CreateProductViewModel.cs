using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product
{
    public class CreateProductViewModel
    {
        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string slug { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "تعداد")]
        public int Quantity { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(2000, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Description { get; set; }

        [Display(Name = "نقد و بررسی")]
        [MaxLength(2000, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? Review { get; set; }


        [Display(Name = "هشدار")]
        [MaxLength(800, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? warning { get; set; }


        [Display(Name = "ارسال رایگان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool FreeShiping { get; set; }

        [Display(Name = "گارانتی")]
        [MaxLength(800, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? warranty { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
       
        public IFormFile  Avatar { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
       
        public int CategoryId { get; set; }
        

    }


    public enum CreateProductResult
    {
        Success
    }
}
