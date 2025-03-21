using Domain.Eshop.Models.Common;
using Domain.Eshop.Models.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Product
{
    public class ProductColor:BaseEntity<int>
    {
        #region Property

        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Color { get; set; }


        [Required]
        [MaxLength(150)]
        public string ColorTitle { get; set; }

        public int? Price { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Quantity { get; set; }

        public bool IsDelete { get; set; }

        #endregion


        #region Relation

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        public ICollection<ProdcutColorOrderDetail>? ProdcutColorOrderDetails { get; set; }

        #endregion
    }
}
