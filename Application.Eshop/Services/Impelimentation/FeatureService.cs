using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Feature;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.Feature;
using Domain.Eshop.ViewModels.ProductFeature;
using Infra.Data.Eshop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class FeatureService(IFeatureRepository featureRepository,
        IProductRepository productRepository,
        IProductFeatureRepository productFeatureRepository) : IFeatureService
    {
        public async Task<CreateFeatureResult> CreateAsync(CreateFeatureViewModel model)
        {
            if (model.ProductId != null )
            
            {
                var product = await productRepository.GetByIdAsync(model.ProductId);
                if (product == null) { return CreateFeatureResult.ProductNotFound; }
                Feature feature = new()
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    Title = model.Title,
                    Value = model.Value,
                    Order = model.Order
                };
                await featureRepository.CreateAsync(feature);
                await featureRepository.SaveAsync();
                ProductFeature productFeature = new ProductFeature
                {
                    ProductId = model.ProductId,
                    FeatureId = feature.Id,
                    CreateDate = DateTime.Now,
                    
                };
                await productFeatureRepository.InsertAsync(productFeature);
                await featureRepository.SaveAsync();
                return CreateFeatureResult.Success;
            }
            return CreateFeatureResult.Error;

        }

        public async Task<DeleteFeatureResult> DeleteAsync(int FeatureId)
        {

            bool result=  await featureRepository.DeleteAsync(FeatureId);
            if (result == true) return DeleteFeatureResult.Success;

            return DeleteFeatureResult.FeatureNotFound;
        }

        public async Task<UpdateFeatureViewModel> GetForUpdateAsync(int FeatureId)
        {
            Feature feature = await featureRepository.GetByIdAsync(FeatureId);
            if(feature == null) { return null; }

            UpdateFeatureViewModel feature1 = new()
            { 
                FeatureId = feature.Id,
                Title = feature.Title,
                Value = feature.Value,
                Order = feature.Order,
             
            };
            return feature1;
        }

        public async Task<UpdateFeatureResult> UpdateAsync(UpdateFeatureViewModel model)
        {
           Feature? feature = await featureRepository.GetByIdAsync(model.FeatureId);
            if(feature == null) {return UpdateFeatureResult.FeatureNotFound;}
            feature.Title = model.Title;
            feature.Value = model.Value;
            feature.Order = model.Order;
            await featureRepository.UpdateAsync(feature);
            return UpdateFeatureResult.Success;
        }
    }
}
