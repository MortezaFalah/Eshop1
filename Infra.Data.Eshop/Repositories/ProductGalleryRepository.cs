using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.Product;
using Domain.Eshop.ViewModels.Product.ProductGallery;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class ProductGalleryRepository(EshopContext _context) : IProductGalleryRepository
    {
        public async Task<bool> DeleteAsync(int id)
        {
            var Image = await GetByIdAsync(id);
            if (Image == null) { return false;  }

            _context.Remove(Image);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<FilterProductGalleryViewModel> FilterAsync(FilterProductGalleryViewModel model)
        {
            var Query = _context.ProductGallery.Where(g => g.ProductId == model.ProductId).AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
            {
                Query = Query.Where(p => p.Title.Contains(model.Title));
            }

            Query = Query.OrderByDescending(v => v.CreateDate);



            await model.Paging(Query.Select(g => new ProductGalleryViewModel
            {
                Id = g.Id,
                ImageName = g.ImageName,
                ProductId = g.ProductId,
                Title = g.Title,
                CreateDate = g.CreateDate

            }));


            return model;
        }

        public async Task<ProductGallery?> GetByIdAsync(int id)
        {
            return await _context.ProductGallery.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task InsertAsync(ProductGallery productGallery)
        {
            await _context.ProductGallery.AddAsync(productGallery);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
