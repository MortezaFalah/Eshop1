using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Feature;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductCategory;
using Domain.Eshop.ViewModels.ProductFeature;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class ProductFeatureRepository(EshopContext _context) : IProductFeatureRepository
    {

        public async Task<FilterProductFeatureViewModel> FilterAsync(FilterProductFeatureViewModel model)
        {
            var Query =  _context.ProductFeatures.Where(X => X.ProductId == model.ProductId)
                .Include(x => x.Product)
                .Include(c => c.Feature)
                .AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(model.Feature))
                Query = Query.Where(pc => pc.Feature != null && pc.Feature.Title.Contains(model.Feature));

            if (!string.IsNullOrEmpty(model.FeatureValue))
                Query = Query.Where(pc => pc.Feature != null && pc.Feature.Value.Contains(model.FeatureValue));

            //if (model.ProductId.HasValue)
            //    Query = Query.Where(pc => pc.ProductId == model.ProductId.Value);
            #endregion


            Query = Query.OrderByDescending(x => x.CreateDate);


            await model.Paging(Query.Select(x => new ProductFeatureViewModel
            {
                FeatureTitle = x.Feature.Title,
                CreateDate = x.CreateDate,
                FeatureValue = x.Feature.Value,
                Id = x.Feature.Id,
                IsDeleted = x.Feature.IsDelete,
                Order = x.Feature.Order,
                ProductTitle = x.Product.Title
            }));


            return model;
        }



        public async Task InsertAsync(ProductFeature model)
          => await _context.ProductFeatures.AddAsync(model);


        public async Task SaveAsync()
          => await _context.SaveChangesAsync();


        public async Task<ProductFeature?> GetByFeatureId(int featureId)
          => await _context.ProductFeatures.FirstOrDefaultAsync(c => c.FeatureId == featureId);
    }
}
