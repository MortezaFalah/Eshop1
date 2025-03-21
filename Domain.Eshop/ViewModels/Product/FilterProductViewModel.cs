using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Eshop.ViewModels.Common;

namespace Domain.Eshop.ViewModels.Product
{
    public class FilterProductViewModel:BasePaging<ProductViewModel>
    {

        public string? ProductName { get; set; }

        public int? Price { get; set; }

        public ProductStatus Status { get; set; }

    }

    public enum ProductStatus
    {
        [Display(Name = "حذف نشده ها")]
        NotDeleted,
        [Display(Name = "حذف شده ها")]
        Deleted,
        [Display(Name ="تمام محصولات")]
        AllProduct,
       
       
    }
}
