using Domain.Eshop.Models.Common;
using Domain.Eshop.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Feature
{
    public class Feature:BaseEntity<int>
    {
        [Required]
        [Display(Name ="عنوان ویژگی")]
        [MaxLength(150, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Title { get; set; }


        [Required]
        [Display(Name = "مقدار ویژگی")]
        [MaxLength(350, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Value { get; set; }


        [Required]
        [Display(Name = "اولویت")]
        public int Order { get; set; }

        [Required]
        [Display(Name = "وضعیت ")]
        public bool IsDelete { get; set; }


        #region relation

        public ICollection<ProductFeature>? ProductFeatures { get; set; }

        #endregion
    }
}
