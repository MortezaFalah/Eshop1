using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.Product.ProductColor;
using Domain.Eshop.ViewModels.ProductFeature;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class ProductColorRepository(EshopContext _context) : IProductColorRepository
    {
        public async Task<FilterProductColorViewModel> FilterAsync(FilterProductColorViewModel model)
        {
            var Query = _context.ProductColor.Where(v => v.ProductId == model.Productid).AsQueryable();


            #region Filter

            if (model.Price.HasValue)
                Query = Query.Where(pc => pc.Price != null && pc.Price.Value == model.Price);

            if (!string.IsNullOrEmpty(model.Color))
                Query = Query.Where(pc => pc.Color != null && pc.Color == model.Color);



            #endregion


            Query = Query.OrderByDescending(x => x.CreateDate);


            await model.Paging(Query.Select(x => new ProductColorViewModel
            {
                Color = x.Color,
                CreateDate = x.CreateDate,
                Id = x.Id,
                IsDelete = x.IsDelete,
                Price = x.Price,
                ColorTitle = x.ColorTitle,
                IsDefault = x.IsDefault
            }));


            return model;
        }


        public async Task InsertAsync(ProductColor Model)
          => await _context.ProductColor.AddAsync(Model);


        public async Task<bool> IsExistColor(ProductColor model)
          => await _context.ProductColor.AnyAsync(x => x.ProductId == model.ProductId && x.Color == model.Color);

        public async Task<bool> IsExistProduct(int productId)
           => await _context.Product.AnyAsync(x => x.Id == productId);

        public async Task SaveAsync()
           => await _context.SaveChangesAsync();


        public async Task<ProductColor?> GetByIdAsync(int id)
          => await _context.ProductColor.FindAsync(id);

        public async Task UpdateAsync(ProductColor model)
            => await _context.ProductColor.Where(x => x.Id == model.Id)
                 .ExecuteUpdateAsync(x => x
                 .SetProperty(z => z.Color, model.Color)
                 .SetProperty(z => z.Price, model.Price)
                 .SetProperty(a => a.IsDefault, model.IsDefault));


        public async Task DeleteAsync(int id)
            => await _context.ProductColor.Where(x => x.Id == id)
               .ExecuteUpdateAsync(x => x
               .SetProperty(b => b.IsDelete, true));

        public async Task<bool> IsExistAnotherDefaultColor()
          => await _context.ProductColor.AnyAsync(f => f.IsDefault);

        public async Task<ProductColor?> GetProductColorForAjax(int productcolorid)
            => await _context.ProductColor.FirstOrDefaultAsync(t => t.Id == productcolorid);

    }
}
