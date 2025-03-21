using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.Product.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class ProductColorService(IProductColorRepository productColorRepository) : IProductColorService
    {
        public async Task<CreateProductColorResult> CreateAsync(CreateProductColorViewModel model)
        {
            if (!await productColorRepository.IsExistProduct(model.ProductId)) 
            { return CreateProductColorResult.ProductNotFount; }
            ProductColor productColor = new()
            {
                Color = model.Color,
                CreateDate = DateTime.Now,
                IsDelete = false,
                Price = model.Price,
                ProductId = model.ProductId,
                ColorTitle = model.ColorTitle,
                IsDefault = model.IsDefault,
                Quantity = model.Count ??0
            };
            if (model.IsDefault == true&& await productColorRepository.IsExistAnotherDefaultColor()) {
                
                return CreateProductColorResult.ExistAnotherDefaultColor;
            }
            if (await productColorRepository.IsExistColor(productColor)) { return CreateProductColorResult.DupplicatedColor; }

            await productColorRepository.InsertAsync(productColor);
            await productColorRepository.SaveAsync();
            return CreateProductColorResult.Success;

        }

   
        public async Task<FilterProductColorViewModel> FilterAsync(FilterProductColorViewModel model)
        {
            return await productColorRepository.FilterAsync(model);
        }

        public async Task<UpdateProductColorViewModel> GetForUpdateAsync(int id)
        {
            ProductColor? productColor = await productColorRepository.GetByIdAsync(id);
            if (productColor == null) { return null; }

            UpdateProductColorViewModel model = new()
            {
                Color = productColor.Color,
                Id = id,
                Price=productColor.Price,
                ProductId=productColor.ProductId,
                IsDefault = productColor.IsDefault,
                ColorTitle= productColor.ColorTitle
                
            };
            return model;
        }

        public async Task<UpdateProductColorResult> UpdateAsync(UpdateProductColorViewModel model)
        {
            if (!await productColorRepository.IsExistProduct(model.ProductId))
            { return UpdateProductColorResult.ProductNotFount; }

            ProductColor? productColor = await productColorRepository.GetByIdAsync(model.Id);
            if (productColor==null)
            { return UpdateProductColorResult.ColorNotFound; }

            if (model.IsDefault == true && await productColorRepository.IsExistAnotherDefaultColor())
            {
                    return UpdateProductColorResult.ExistAnotherDefaultColor;
            }
            productColor.Color = model.Color;
            productColor.ColorTitle = model.ColorTitle;
            productColor.IsDefault = model.IsDefault;
            productColor.Price = model.Price;
            productColor.Quantity = model.Count ?? 0;
            await productColorRepository.UpdateAsync(productColor);
            await productColorRepository.SaveAsync();
            return UpdateProductColorResult.Success;

        }


        public async Task<DeleteProductColorResult> DeleteAsync(int id)
        {
            ProductColor? productColor = await productColorRepository.GetByIdAsync(id);
            if (productColor == null)
            { return DeleteProductColorResult.ProductColorNotFound; }

           await productColorRepository.DeleteAsync(id);
           return DeleteProductColorResult.Success;

        }

        public async Task<ProductColorViewModel> GetProductColorForAjaxAsync(int Productcolorid)
        {
            ProductColor? color =  await productColorRepository.GetProductColorForAjax(Productcolorid);
            if (color == null) { return null; }
            ProductColorViewModel colorViewModel = new()
            {
                ColorTitle = color.ColorTitle,
                Color = color.Color,
                Id = color.Id,
                Price = color.Price
            };
            return colorViewModel;
        }
    }
}
