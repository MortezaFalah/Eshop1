using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.ProductComment
{
    public class AddProductCommentViewModel
    {
        [Required]
        public int ProductId { get; set; }

        public int? Userid { get; set; }

        [Required]
        [MaxLength(2000)]
        [Display(Name ="متن کامنت")]
        public string Text { get; set; }

        [Display(Name ="مزایا")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(800,ErrorMessage ="تعداد کارکتر های وارد شده بیش از حد مجاز میباشد")]
        public string Advantages { get; set; }

        [Display(Name = "معایب")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "تعداد کارکتر های وارد شده بیش از حد مجاز میباشد")]
        public string DisAdvantages { get; set; }
    }

    public enum AddProductCommentResult
    {
        Success,
        Feild,
    }
}
