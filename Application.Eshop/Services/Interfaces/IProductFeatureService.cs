using Domain.Eshop.ViewModels.ProductFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IProductFeatureService
    {
        Task<FilterProductFeatureViewModel> FilterAsync(FilterProductFeatureViewModel model);

        //Task<CreateProductFeatureResult> CreateAsync(CreateProductFeatureViewModel model);
    }
}
