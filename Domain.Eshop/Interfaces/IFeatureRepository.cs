using Domain.Eshop.Models.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IFeatureRepository
    {

       Task CreateAsync(Feature model);

        Task SaveAsync();

        Task<bool> DeleteAsync(int featureId);

        Task<Feature> GetByIdAsync(int featureid);

        void Update(Feature feature);

        Task UpdateAsync(Feature model);


    }
}
