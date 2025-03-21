using Domain.Eshop.ViewModels.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IFeatureService
    {
        Task<CreateFeatureResult> CreateAsync(CreateFeatureViewModel model);

        Task<DeleteFeatureResult> DeleteAsync(int FeatureId);

       Task<UpdateFeatureViewModel> GetForUpdateAsync(int FeatureId);

        Task<UpdateFeatureResult> UpdateAsync(UpdateFeatureViewModel model);
    }
}
