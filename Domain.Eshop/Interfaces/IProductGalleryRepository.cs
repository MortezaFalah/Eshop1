using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.Product.ProductGallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IProductGalleryRepository
    {
        Task<FilterProductGalleryViewModel> FilterAsync(FilterProductGalleryViewModel model);

        Task InsertAsync(ProductGallery productGallery);

        Task SaveAsync();

       Task<bool> DeleteAsync(int id);

        Task<ProductGallery> GetByIdAsync(int id);

    }
}
