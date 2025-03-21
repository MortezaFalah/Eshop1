
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Eshop.ViewModels.Product;
using Domain.Eshop.ViewModels.ProductCategory;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Product;
using Application.Eshop.Extentions;
using System.Reflection.Metadata.Ecma335;
using Application.Eshop.Statics;
using Application.Eshop.Services.Interfaces;
using Infra.Data.Eshop.Repositories;
using Domain.Eshop.ViewModels.Product.ClientSideProductDetail;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Application.Eshop.Services.Impelimentation
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task<CreateProductResult> CreateAsync(CreateProductViewModel model)
        {
            Product product = new()
            {
                CreateDate = DateTime.Now,
                Title = model.Title,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Price = model.Price,
                IsDeleted = false,
                Slug = model.slug,
                Quantity = model.Quantity,
                warranty = model.warranty,
                Review = model.Review,
                warning = model.warning,
                Freeshipping = model.FreeShiping,

            };
            #region Add Avatar
            if (model.Avatar != null)
            {
                string imagename = Guid.NewGuid().ToString() + Path.GetExtension(model.Avatar.FileName);

                string imgagepath = PathTools.ProductImagePath;

                model.Avatar.AddImageToServer(imagename, imgagepath);

                product.AvatarName = imagename;
            }

            #endregion
            await productRepository.InsertAsync(product);
            await productRepository.SaveAsync();
            return CreateProductResult.Success;
        }

        public async Task<DeleteProductResult> DeleteAsync(int id)
        {
            Product? product = await productRepository.GetByIdAsync(id);

            if (product == null) { return DeleteProductResult.ProductNotFound; }

            product.IsDeleted = true;
            productRepository.Update(product);
            await productRepository.SaveAsync();
            return DeleteProductResult.Success;
        }



        public async Task<FilterProductViewModel> FilterAsync(FilterProductViewModel? model)
        {
            return await productRepository.FilterAsync(model);
        }

        public async Task<ClientSideFilterProductViewModel> FilterAsync(ClientSideFilterProductViewModel? model)
        {
            return await productRepository.FilterAsync(model);
        }

        public async Task<UpdateProductViewModel> GetProductForUpdate(int id)
        {
            Product? product = await productRepository.GetByIdAsync(id);
            if (product == null) { return null; }

            return new UpdateProductViewModel
            {
                AvatarName = product.AvatarName,
                CategoryId = product.CategoryId,
                Description = product.Description,
                IsDeleted = false,
                Price = product.Price,
                ProductId = product.Id,
                Title = product.Title,
                slug = product.Slug,
                Quantity = product.Quantity,
                Warranty = product.warranty,
                Review = product.Review,
                warning = product.warning,
                FreeShiping = product.Freeshipping,
            };

        }

        public async Task<UpdateProductResult> UpdateAsync(UpdateProductViewModel model)
        {
            Product? product = await productRepository.GetByIdAsync(model.ProductId);
            if (product == null) { return UpdateProductResult.ProductNotFound; }
            product.Title = model.Title;
            product.Description = model.Description;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;
            product.Slug = model.slug;
            product.Quantity = model.Quantity;
            product.warranty = model.Warranty;
            product.Review = model.Review;
            product.warning = model.warning;
            product.Freeshipping = model.FreeShiping;


            if (model.NewAvatar != null)
            {
                string imagename = Guid.NewGuid().ToString() + Path.GetExtension(model.NewAvatar.FileName);

                string imgagepath = PathTools.ProductImagePath;

                model.NewAvatar.AddImageToServer(imagename, imgagepath, null, null, null, model.AvatarName);

                product.AvatarName = imagename;
            }

            productRepository.Update(product);
            await productRepository.SaveAsync();
            return UpdateProductResult.Success;

        }


        public async Task<ClientSideProductDetailViewModel> DetailsAsync(string slug)
        {
            var product = await productRepository.GetBySlugAsync(slug);
            if (product == null) { return null; }



            ClientSideProductDetailViewModel viewModel = new()
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                AvatarName = product.AvatarName,
                ProductId = product.Id,
                warning = product.warning,
                FreeShiping = product.Freeshipping,
                Quantity = product.Quantity,
                Review = product.Review,
                warranty = product.warranty,

                ProductGalleries = product.ProductGalleries
               .Select(c => new DetailProductGalleryViewModel
               { AvatarTitle = c.Title, AvatarName = c.ImageName }).ToList() ?? null,

                Categories = await productRepository.GetAllCategoryAsync(product.ProductCategory.Id),

                ProductColors = product.ProductColors.Where(r=>!r.IsDelete)
               .Select(x => new DetailProductColorViewModel
               { Color = x.Color, Price = x.Price, ColorId = x.Id ,
                   IsDefault =x.IsDefault, ColorTitle = x.ColorTitle}).ToList() ?? null,

                ProductFeatures = product.ProductFeatures
               .Select(Q => new DetailProductFeatureViewModel
               { Title = Q.Feature.Title, Value = Q.Feature.Value, Order = Q.Feature.Order }).ToList() ?? null,

            }; 
            return viewModel;

        }

        public async Task<ClientSideFilterProductViewModel> GetAllProductsInCategory(ClientSideFilterProductViewModel model)
           => await productRepository.GetAllProductsCategory(model);
    }
}
