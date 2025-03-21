using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.Product.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IProductColorRepository
    {
        Task<FilterProductColorViewModel> FilterAsync(FilterProductColorViewModel model);

        Task InsertAsync(ProductColor Model);

        Task SaveAsync();

        Task<bool> IsExistColor(ProductColor model);

        Task<bool> IsExistProduct(int productId);

        Task<ProductColor?> GetByIdAsync(int id);

        Task UpdateAsync(ProductColor model);


        Task DeleteAsync(int id);

        Task<bool> IsExistAnotherDefaultColor();

        Task<ProductColor?> GetProductColorForAjax(int productcolorid);

    }
}
