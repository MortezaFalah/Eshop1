using Domain.Eshop.Models.Common;
using Domain.Eshop.Models.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Product
{
    public class Product : BaseEntity<int>
    {

        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(2000, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Description { get; set; }

        [Display(Name = "عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string AvatarName { get; set; }

        [Required]
        [Display(Name = "slug")]
        [MaxLength(250, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Slug { get; set; }

    
        [Display(Name = "نقد و بررسی")]
        [MaxLength(2000, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? Review { get; set; }

        [Display(Name = "هشدار")]
        [MaxLength(800, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? warning { get; set; }

        [Required]
        [Display(Name = "ارسال رایگان")]
        public bool Freeshipping { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
       
        public int CategoryId { get; set; }

        [Display(Name = "گارانتی")]
        [MaxLength(150, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string? warranty { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Quantity { get; set; }


        public bool IsDeleted { get; set; } = false;


        #region Relation
        [ForeignKey(nameof(CategoryId))]
        public ProductCategory? ProductCategory { get; set; }


        public ICollection<ProductGallery>? ProductGalleries { get; set; }


        public ICollection<ProductFeature>? ProductFeatures { get; set; }

        public ICollection<ProductColor>? ProductColors { get; set; }

        public ICollection<OrderDetail>?  OrderDetails { get; set; }

        public ICollection<ProductComment>? ProductComment { get; set; }

        public ICollection<CommentReaction>? CommentReactions { get; set; }

        #endregion
    }
}
