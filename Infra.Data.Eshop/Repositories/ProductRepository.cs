using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Eshop.ViewModels.Product;
using Domain.Eshop.ViewModels.ProductCategory;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Eshop.ViewModels.Product.ClientSideProductDetail;

namespace Infra.Data.Eshop.Repositories
{
    public class ProductRepository(EshopContext _context) : IProductRepository
    {


        public async Task<FilterProductViewModel> FilterAsync(FilterProductViewModel model)
        {
            var Query = _context.Product.AsQueryable();

            if (!string.IsNullOrEmpty(model.ProductName))
            {
                Query = Query.Where(p => p.Title.Contains(model.ProductName) || p.Description.Contains(model.ProductName));
            }
            if (model.Price != null)
            {
                Query = Query.Where(p => p.Price == model.Price);
            }

            switch (model.Status)
            {
                case ProductStatus.AllProduct:
                    break;
                case ProductStatus.NotDeleted:
                    Query = Query.Where(F => !F.IsDeleted);
                    break;
                case ProductStatus.Deleted:
                    Query = Query.Where(F => F.IsDeleted);
                    break;
            }

            Query = Query.OrderByDescending(v => v.CreateDate);


            await model.Paging(Query.Select(c => new ProductViewModel
            {
                AvatarName = c.AvatarName,
                Id = c.Id,
                Price = c.Price,
                Title = c.Title,
                CategoryId = c.CategoryId,
                CreateDate = c.CreateDate,
                Description = c.Description,
                IsDeleted = c.IsDeleted
            }));

            return model;

        }

        public async Task<ClientSideFilterProductViewModel> FilterAsync(ClientSideFilterProductViewModel model)
        {
            var Query = _context.Product.Where(f => !f.IsDeleted).AsQueryable();

            if (!string.IsNullOrEmpty(model.ProductName))
            {
                Query = Query.Where(p => p.Title.Contains(model.ProductName) || p.Description.Contains(model.ProductName));
            }
            if (model.Price != null)
            {
                Query = Query.Where(p => p.Price == model.Price);
            }



            Query = Query.OrderByDescending(v => v.CreateDate);


            await model.Paging(Query.Select(c => new ClientSideProductViewModel
            {
                AvatarName = c.AvatarName,
                Id = c.Id,
                Price = c.Price,
                Title = c.Title,
                CategoryId = c.CategoryId,
                Description = c.Description,
                Slug = c.Slug
            }));

            return model;
        }

        public async Task<Product?> GetByIdAsync(int id)
       => await _context.Product.FirstOrDefaultAsync(r => r.Id == id);


        public async Task InsertAsync(Product product)
          => await _context.Product.AddAsync(product);

        public async Task SaveAsync()
         => await _context.SaveChangesAsync();



        public void Update(Product product)
        => _context.Product.Update(product);



        public async Task<Product> GetBySlugAsync(string slug)
        {

            var model = await _context.Product
                .Include(x => x.ProductGalleries)
                .Include(f => f.ProductCategory)
                .Include(c => c.ProductColors)
                .Include(w => w.ProductFeatures)
                .ThenInclude(a => a.Feature)
                .FirstOrDefaultAsync(e => e.Slug.Contains(slug) && !e.IsDeleted);
            return model;
        }

        public async Task<List<DetailProdcutCategoryViewModel>>? GetAllCategoryAsync(int categoryid)
        {
            List<DetailProdcutCategoryViewModel> productCategories = new List<DetailProdcutCategoryViewModel>();
            var currentCategory = await _context.ProductCategories
                .FirstOrDefaultAsync(c => c.Id == categoryid && !c.IsDeleted);


            if (currentCategory == null)
            {
                return productCategories;
            }


            while (currentCategory.ParentId != null)
            {
                DetailProdcutCategoryViewModel prodcutCategory = new()
                {
                    Title = currentCategory.Title,
                    Id = currentCategory.Id,
                    ParentId = currentCategory.ParentId,
                };

                productCategories.Add(prodcutCategory);


                currentCategory = await _context.ProductCategories
                     .FirstOrDefaultAsync(c => c.Id == prodcutCategory.ParentId && !c.IsDeleted);


            }
            if (currentCategory.ParentId == null)
            {
                productCategories.Add(new() { Title = currentCategory.Title, Id = currentCategory.Id, ParentId = null });
            }

            productCategories.Reverse();
            return productCategories;
        }

        public async Task<ClientSideFilterProductViewModel> GetAllProductsCategory(ClientSideFilterProductViewModel model)
        {
            var Query = _context.Product.Where(f => !f.IsDeleted && f.CategoryId==model.CategoryId).AsQueryable();

            if (!string.IsNullOrEmpty(model.ProductName))
            {
                Query = Query.Where(p => p.Title.Contains(model.ProductName) || p.Description.Contains(model.ProductName));
            }
            if (model.Price != null)
            {
                Query = Query.Where(p => p.Price == model.Price);
            }



            Query = Query.OrderByDescending(v => v.CreateDate);


            await model.Paging(Query.Select(c => new ClientSideProductViewModel
            {
                AvatarName = c.AvatarName,
                Id = c.Id,
                Price = c.Price,
                Title = c.Title,
                CategoryId = c.CategoryId,
                Description = c.Description,
                Slug = c.Slug
            }));

            return model;
        }
    }
}
