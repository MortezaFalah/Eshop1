using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryViewModel>> GetAllAsync(); 

        Task<CreateProductCategoryResult> CreateAsync(CreateProductCategoryViewModel model);

        Task<List<ProductCategoryViewModel>> GetAllParents();

        Task<UpdateProductCategoryResult> UpdateAsync(UpdateProductCategoryViewModel model);


        Task<UpdateProductCategoryViewModel> GetProductCategoryForUpdate(int id);


        Task<DeleteProductCategoryResult> DeleteAsync(int id);


        Task<FilterProductCategoryViewModel> FilterAsync(FilterProductCategoryViewModel model);

        Task<List<ProductCategoryViewModel>> GetAllChildAsync();
    }
}
