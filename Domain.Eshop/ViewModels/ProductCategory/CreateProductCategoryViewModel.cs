using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.ProductCategory
{
    public class CreateProductCategoryViewModel
    {
        [MaxLength(45, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "عنوان گروه")]
        public string Title { get; set; }


        [Display(Name = "عنوان والد")]
        public int? ParentId { get; set; }
    }


   public enum CreateProductCategoryResult
    {
        Success
    }


}
