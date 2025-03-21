using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product.ProductColor
{
    public class CreateProductColorViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Display(Name = "کد رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]

        public string Color { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string ColorTitle { get; set; }

        [Display(Name ="تعداد ")]
        public int? Count { get; set; }

        [Display(Name = "آیا این رنگ پیشفرض محصول است؟")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsDefault { get; set; }

        [Display(Name = "قیمت")]

        public int? Price { get; set; } 


    }
    public enum CreateProductColorResult
    {
        Success,
        ProductNotFount,
        DupplicatedColor,
        ExistAnotherDefaultColor
    }
}
