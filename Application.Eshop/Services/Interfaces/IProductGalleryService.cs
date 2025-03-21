using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.Product.ProductGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IProductGalleryService
    {

        Task<FilterProductGalleryViewModel> FilterAsync(FilterProductGalleryViewModel model);

        Task<CreateProductGalleryResult> CreateAsync(CreateProductGalleryViewModel model);


        Task SaveAsync();


        Task<DeleteProductGalleryResult> DeleteAsync(int id);
    }
   
}
