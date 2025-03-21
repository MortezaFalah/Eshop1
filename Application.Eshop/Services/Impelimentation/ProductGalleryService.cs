using Application.Eshop.Extentions;
using Application.Eshop.Services.Interfaces;
using Application.Eshop.Statics;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.Product.ProductGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class ProductGalleryService(IProductGalleryRepository productGalleryRepository) : IProductGalleryService
    {

        public async Task<CreateProductGalleryResult> CreateAsync(CreateProductGalleryViewModel model)
        {

            if (model.FileImage != null)
            {

                string imagename = Guid.NewGuid().ToString() + Path.GetExtension(model.FileImage.FileName);

                string imgagepath = PathTools.ProductImageGalleryPath;

                model.FileImage.AddImageToServer(imagename, imgagepath);




                ProductGallery productGallery = new ProductGallery();
                productGallery.ImageName = imagename;
                productGallery.CreateDate = DateTime.Now;
                productGallery.Title = model.Title;
                productGallery.ProductId = model.ProductId;
                await productGalleryRepository.InsertAsync(productGallery);
                await productGalleryRepository.SaveAsync();
                return CreateProductGalleryResult.success;
            }
            return CreateProductGalleryResult.Error;

        }

        public async Task<DeleteProductGalleryResult> DeleteAsync(int id)
        {
            ProductGallery image = await productGalleryRepository.GetByIdAsync(id);
            if (await productGalleryRepository.DeleteAsync(id))
            {
               

                image.ImageName?.DeleteImage(PathTools.ProductImageGalleryPath);

                //string imgagepath = PathTools.ProductImageGalleryPath + image.ImageName;
                //if (File.Exists(imgagepath))
                //{
                //    File.Delete(imgagepath);
                //}
                return DeleteProductGalleryResult.Success;
            }
            return DeleteProductGalleryResult.NotFound;
        }

        public async Task<FilterProductGalleryViewModel> FilterAsync(FilterProductGalleryViewModel model)
        {
            return await productGalleryRepository.FilterAsync(model);
        }

        public async Task SaveAsync()
        {
            await productGalleryRepository.SaveAsync();
        }
    }
}
