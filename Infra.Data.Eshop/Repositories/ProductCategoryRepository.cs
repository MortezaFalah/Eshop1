using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductCategory;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class ProductCategoryRepository
        (EshopContext _context) : IProductCategoryRepository
    {
        public async Task<FilterProductCategoryViewModel> FilterAsync(FilterProductCategoryViewModel model)
        {
            var Query = _context.ProductCategories.AsQueryable();

            if (!string.IsNullOrEmpty(model.Title))
            {
                Query = Query.Where(c => c.Title == model.Title);
            }
            Query = Query.OrderByDescending(x => x.CreateDate);

            await model.Paging(Query.Select(c => new ProductCategoryViewModel
            {
                Title = c.Title,
                CreateDate = c.CreateDate,
                Id = c.Id,
                ParentId = c.ParentId,

            }));

            return model;

        }

        public async Task<List<ProductCategoryViewModel>> GetAllAsync()
        {
            return await _context.ProductCategories.Where(c => !c.IsDeleted).Select(v => new ProductCategoryViewModel
            {
                CreateDate = v.CreateDate,
                ParentId = v.ParentId,
                Id = v.Id,
                Title = v.Title

            }).ToListAsync();
        }

        public async Task<List<ProductCategoryViewModel>> GetAllChildAsync()
        {
            return await _context.ProductCategories.Where(c => !c.IsDeleted && c.ParentId.HasValue).Select(v => new ProductCategoryViewModel
            {
                ParentId = v.ParentId,
                Id = v.Id,
                Title = v.Title
            }).ToListAsync();

        }

        public async Task<List<ProductCategoryViewModel>> GetAllParentAsync()
        {
            return await _context.ProductCategories.Where(v => v.ParentId == null).Select(r => new
                 ProductCategoryViewModel
            {
                Id = r.Id,
                ParentId = r.ParentId,
                Title = r.Title,
            }).ToListAsync();
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        public async Task<UpdateProductCategoryViewModel> GetForUpdate(int id)
        {
            return await _context.ProductCategories.Where(z => z.Id == id).Select(f => new UpdateProductCategoryViewModel
            {
                Id = f.Id,
                ParentId = f.ParentId,
                Title = f.Title,
            }).FirstAsync();
        }

        public async Task InsertAsync(ProductCategory productcategory)
        {
            await _context.ProductCategories.AddAsync(productcategory);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(ProductCategory productcategory)
        {
            _context.ProductCategories.Update(productcategory);
        }
    }
}
