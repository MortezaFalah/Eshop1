using Domain.Eshop.ViewModels.Product.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IProductColorService
    {

        Task<FilterProductColorViewModel> FilterAsync(FilterProductColorViewModel model);

        Task<CreateProductColorResult> CreateAsync(CreateProductColorViewModel model);

        Task<UpdateProductColorViewModel> GetForUpdateAsync(int id);

        Task<UpdateProductColorResult> UpdateAsync(UpdateProductColorViewModel model);

        Task<DeleteProductColorResult> DeleteAsync(int id);

        Task<ProductColorViewModel> GetProductColorForAjaxAsync(int Productcolorid);
    }
}
