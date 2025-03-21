using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        public async Task<OrderViewModel>? GetCartItemsAsync(int userid)
        {
            return await orderRepository.GetUserCartItemsAsync(userid);
        }
    }
}
