using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class ProductCategoryService
        (IProductCategoryRepository productcategoryrepository) :
        IProductCategoryService
    {
        public async Task<CreateProductCategoryResult> CreateAsync(CreateProductCategoryViewModel model)
        {
            ProductCategory productCategory = new()
            {
                Title = model.Title,
                CreateDate = DateTime.Now,
                ParentId = model.ParentId,

            };

            await productcategoryrepository.InsertAsync(productCategory);
            await productcategoryrepository.SaveAsync();
            return CreateProductCategoryResult.Success;
        }

        public async Task<DeleteProductCategoryResult> DeleteAsync(int id)
        {
            ProductCategory? productCategory =await  productcategoryrepository.GetByIdAsync(id);

            if (productCategory == null) { return DeleteProductCategoryResult.ProductCategoryNotFound; }

            productCategory.IsDeleted = true;
            productcategoryrepository.Update(productCategory);
            await productcategoryrepository.SaveAsync();
            return DeleteProductCategoryResult.Success;
        }

        public async Task<FilterProductCategoryViewModel> FilterAsync(FilterProductCategoryViewModel model)
        {
            return await productcategoryrepository.FilterAsync(model);
        }

        public async Task<List<ProductCategoryViewModel>> GetAllAsync()
        {
            return await productcategoryrepository.GetAllAsync();
        }

        public async Task<List<ProductCategoryViewModel>> GetAllChildAsync()
        {
           return await productcategoryrepository.GetAllChildAsync();
        }

        public async Task<List<ProductCategoryViewModel>>? GetAllParents()
        {
            return await productcategoryrepository.GetAllParentAsync();
        }

        public async Task<UpdateProductCategoryViewModel> GetProductCategoryForUpdate(int id)
        {
            UpdateProductCategoryViewModel productCategory = await productcategoryrepository.GetForUpdate(id);
            if (productCategory == null) { return null; }

            return productCategory;
        }

        public async Task<UpdateProductCategoryResult> UpdateAsync(UpdateProductCategoryViewModel model)
        {

            ProductCategory? productCategory = await productcategoryrepository.GetByIdAsync(model.Id);
            if (productCategory == null) { return UpdateProductCategoryResult.ProductCategoryNotFound; }

            productCategory.ParentId = model.ParentId;
            productCategory.Title = model.Title;
            productcategoryrepository.Update(productCategory);
            await productcategoryrepository.SaveAsync();

            return UpdateProductCategoryResult.Success;
        }
    }
}
