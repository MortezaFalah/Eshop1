using Domain.Eshop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product.ProductColor
{
    public class FilterProductColorViewModel:BasePaging<ProductColorViewModel>
    {
        [Display(Name = "قیمت")]
        public int?  Price { get; set; }

        [Display(Name = "کد رنگ")]
        public string? Color { get; set; }

        public int Productid { get; set; }
    }
}
