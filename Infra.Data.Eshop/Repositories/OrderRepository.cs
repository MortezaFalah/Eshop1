using Domain.Eshop.Interfaces;
using Domain.Eshop.ViewModels.Order;
using Domain.Eshop.ViewModels.OrderDetail;
using Domain.Eshop.ViewModels.Product.ProductColor;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class OrderRepository(EshopContext _context) : IOrderRepository
    {
        public async Task<OrderViewModel?> GetUserCartItemsAsync(int userid)
             => await _context.Order
                .Include(p => p.OrderDetails)
                .ThenInclude(o => o.Product)
                .ThenInclude(t => t.ProductColors)
                .Select(u => new OrderViewModel
                {
                    UserId = u.UserId,
                    CreateDate = u.CreateDate,
                    IsFinally = u.IsFinally,
                    OrderNumber = 0,
                    type = u.Type,
                    OrderDetails = u.OrderDetails
                    .Select(e => new OrderDetailViewModel
                    {
                        ProductColor = e.Product.ProductColors.Select(r => new ProductColorViewModel
                        {
                            Color = r.Color,
                            ColorTitle = r.ColorTitle,
                            CreateDate = r.CreateDate,
                            IsDefault = r.IsDefault,
                            Id = r.Id,

                        }).ToList(),
                        Id = e.Id,
                        Price = e.Price,
                        Quantity = e.Quantity,
                        ProducId = e.ProducId,
                        ProductAvatar = e.Product.AvatarName,
                        ProductTitle = e.Product.Title,
                        Warranty = e.Product.warranty,

                    }).ToList()

                }).FirstOrDefaultAsync(r => r.UserId == userid && !r.IsFinally);


    }
}
