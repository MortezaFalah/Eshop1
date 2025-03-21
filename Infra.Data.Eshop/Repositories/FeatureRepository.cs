using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Feature;
using Domain.Eshop.Models.Product;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class FeatureRepository(EshopContext _context, IProductFeatureRepository productFeatureRepository) : IFeatureRepository
    {
        public async Task CreateAsync(Feature model)
        {
            await _context.AddAsync(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int featureId)
        {
            Feature? feature = await GetByIdAsync(featureId);
            if (feature == null) { return false; }

            feature.IsDelete = true;
            Update(feature);



            var productFeature = await productFeatureRepository.GetByFeatureId(featureId);
            if (productFeature == null) { return false; }
            productFeature.IsDelete = true;

            await SaveAsync();

            return true;


        }

        public async Task<Feature?> GetByIdAsync(int featureid)
            => await _context.Features.FirstOrDefaultAsync(c => c.Id == featureid);


        public void Update(Feature model)
            => _context.Update(model);

        public async Task UpdateAsync(Feature model)
           => await _context.Features
                           .Where(f => f.Id == model.Id)
                           .ExecuteUpdateAsync(f => f.SetProperty(x => x.Title, model.Title)
                                                       .SetProperty(x => x.Value, model.Value)
                                                       .SetProperty(x => x.Order, model.Order));



    }
}
