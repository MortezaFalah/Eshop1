using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product.ProductColor
{
    public class ProductColorViewModel
    {

        public int Id { get; set; }
        [Display(Name = "کد رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]


        public string Color { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string ColorTitle { get; set; }

        [Display(Name = "قیمت این رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public int? Price { get; set; }

        [Display(Name = "رنگ پیشفرض")]
        public bool IsDefault { get; set; }

        [Display(Name = "تاریخ ایجاد رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime CreateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
