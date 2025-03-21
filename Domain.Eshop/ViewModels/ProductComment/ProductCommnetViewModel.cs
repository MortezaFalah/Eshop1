using Domain.Eshop.Models.Enums.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.ProductComment
{
    public class ProductCommnetViewModel
    {

      
        public int ProductId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "متن کامنت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(2000, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Text { get; set; }

        [Display(Name = "مزایا")]
        [MaxLength(800, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Advantage { get; set; }

        [Display(Name = "معایب")]
        [MaxLength(800, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string DisAdvantage { get; set; }

        [Display(Name = "وضعیت کامنت")]
        public CommentStatus Status { get; set; }

        public string UserFullname { get; set; }
    }
}
