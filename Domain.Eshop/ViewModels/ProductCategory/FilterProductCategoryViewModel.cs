using Domain.Eshop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.ProductCategory
{
    public class FilterProductCategoryViewModel:BasePaging<ProductCategoryViewModel>
    {
        public string? Title { get; set; }
    }
}
