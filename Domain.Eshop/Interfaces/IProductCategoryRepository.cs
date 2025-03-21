using Domain.Eshop.Models.Product;
using Domain.Eshop.Models.User;
using Domain.Eshop.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategoryViewModel>> GetAllAsync();

        Task InsertAsync(ProductCategory productcategory);


        Task SaveAsync();

        void Update(ProductCategory productcategory);



        Task<List<ProductCategoryViewModel>> GetAllParentAsync();


        Task<UpdateProductCategoryViewModel> GetForUpdate(int id);

        Task<ProductCategory?> GetByIdAsync(int id);


        Task<FilterProductCategoryViewModel> FilterAsync(FilterProductCategoryViewModel model);

        Task<List<ProductCategoryViewModel>> GetAllChildAsync();
       
    }
}
