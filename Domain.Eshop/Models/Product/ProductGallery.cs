using Domain.Eshop.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Product
{
    public class ProductGallery : BaseEntity<int>
    {

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Title { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(250, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string ImageName { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductId { get; set; }


        #region Relation
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        #endregion
    }
}
