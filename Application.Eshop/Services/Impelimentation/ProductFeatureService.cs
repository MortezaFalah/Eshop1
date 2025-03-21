using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Feature;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductFeature;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class ProductFeatureService(IProductFeatureRepository productFeatureRepository,
        IProductRepository productRepository) : IProductFeatureService
    {
        //Todo Delete this method
        //public async Task<CreateProductFeatureResult> CreateAsync(CreateProductFeatureViewModel model)
        //{
        //    var product = await productRepository.GetByIdAsync(model.ProductId);
        //    if (product == null) { return CreateProductFeatureResult.ProductNotFound; }

        //    ProductFeature productFeature = new()
        //    {
              
        //        CreateDate = DateTime.Now,
        //        ProductId = product.Id,
                

        //    };

        //    //await productFeatureRepository.InsertAsync(feature);
        //    //await productFeatureRepository.SaveAsync();
        //    return CreateProductFeatureResult.Success;

        //}

        public async Task<FilterProductFeatureViewModel> FilterAsync(FilterProductFeatureViewModel model)
        {
            return await productFeatureRepository.FilterAsync(model);
        }
    }
}
