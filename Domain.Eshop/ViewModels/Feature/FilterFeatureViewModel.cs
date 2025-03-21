using Domain.Eshop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Feature
{
    public class FilterFeatureViewModel:BasePaging<FeatureViewModel>
    {
        [Display(Name ="محصول")]
        public int? ProductId { get; set; }

        [Display(Name = "عنوان ویژگی")]
        public string? FeatureTitle { get; set; }
    }
}
