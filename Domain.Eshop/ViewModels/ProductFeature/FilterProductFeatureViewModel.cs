using Domain.Eshop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.ProductFeature
{
    public class FilterProductFeatureViewModel:BasePaging<ProductFeatureViewModel>
    {
        [Display(Name ="ویژگی")]
        public string? Feature { get; set; }

        [Display(Name = "مقدار ویژگی")]
        public string?  FeatureValue { get; set; }


        public int? ProductId { get; set; }



    }
}
