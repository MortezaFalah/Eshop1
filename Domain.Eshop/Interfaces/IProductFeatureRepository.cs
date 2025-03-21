using Domain.Eshop.Models.Feature;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IProductFeatureRepository
    {

        Task<FilterProductFeatureViewModel> FilterAsync(FilterProductFeatureViewModel model);


        Task InsertAsync(ProductFeature model);

        Task SaveAsync();


        Task<ProductFeature> GetByFeatureId(int featureId);
    }
}
